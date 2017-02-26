var gameModel = {};
var loginModel = {};
var loginResponse = "";
var loginUser = "";
var boardSize = 5;
var boardModel = new Array(boardSize * boardSize);
var playersOnGame = ["", ""];
var refreshGameModel;
var winAlerted = false;

var en = i18n.create({
    values: {
        "loginButton": "login", "title": "Tic Tac Toe", "nameLbl": "user name: ", "passwordLbl": "password",
        "signInButton": "sign in", "logOutButton": "log Out", "resetButton": "start/reset", "boardSizeLbl": "board size",
        "numberForWinLbl": "number for Win",
        "loginError": "incorrect username or password", "onLine": "online: ", "wonPlayer": "Won player ",
        "Congratulations": ". Congratulations!", "YouAreOrange": "You are already in the game as a player orange",
        "joinGreen": "You joined the game as a player green", "YouAreGreen": "You are already in the game as a player green",
        "joinOrange": "You joined the game as a player orange", "colorBusy": "This color is already busy",
        "mustLoginAndJoin": "you must first log in and join the game", "mustJoin": "you must first join the game",
        "wait": "wait for his move", "areaOccupied": "this area is already occupied", "serverNotResponsed": "server not responsed"
    }
})
var pl = i18n.create({
    values: {
        "loginButton": "logowanie", "title": "Kółko i Krzyżyk", "nameLbl": "nazwa użytkownika: ", "passwordLbl": "hasło",
        "signInButton": "zaloguj", "logOutButton": "wyloguj", "resetButton": "rozpocznij/kasuj", "boardSizeLbl": "rozmiar planszy",
        "numberForWinLbl": "liczba do wygranej",
        "loginError": "niepoprawna nazwa użytkowanika lub hasło", "onLine": "zalogowany: ", "wonPlayer": "Wygrał gracz ",
        "Congratulations": ". Gratulacje!", "YouAreOrange": "Dołączyłeś już do gry jako gracz pomarańczowy",
        "joinGreen": "Dołączyłeś do gry jako gracz zielony", "YouAreGreen": "Dołączyłeś już do gry jako gracz zielony",
        "joinOrange": "Dołączyłeś do gry jako gracz pomarańczowy", "colorBusy": "Ten kolor jest już zajęty",
        "mustLoginAndJoin": "trzeba się najpierw zalogować i dołączyć do gry", "mustJoin": "musisz najpierw dołączyć do gry",
        "wait": "zaczekaj na swój ruch", "areaOccupied": "to pole jest już zajęte", "serverNotResponsed": "serwer nie odpowiedział"
    }
})
var es = i18n.create({
    values: {
        "loginButton": "login", "title": "Tic Tac Toe", "nameLbl": "nombre de usuario: ", "passwordLbl": "contraseña",
        "signInButton": "iniciar la sesión", "logOutButton": "log", "resetButton": "iniciar / borrar", "boardSizeLbl": "tamaño del tablero",
        "numberForWinLbl": "Número de ganar",
        "loginError": "nombre de usuario o contraseña incorrecta", "onLine": "en línea: ", "wonPlayer": "ganó el jugador ",
        "Congratulations": ". Felicitaciones!", "YouAreOrange": "Ya estás en el juego como un jugador de naranja",
        "joinGreen": "Que se unió al juego como un jugador verde", "YouAreGreen": "Ya estás en el juego como un jugador verde",
        "joinOrange": "Que se unió al juego como un jugador de naranja", "colorBusy": "Este color ya está ocupado",
        "mustLoginAndJoin": "primero debe iniciar sesión en el juego y unirse", "mustJoin": "que primero debe unirse al juego",
        "wait": "esperar a que su movimiento", "areaOccupied": "Esta área ya está ocupado", "serverNotResponsed": "Servidor no respondió"
    }
})
var lang = pl;


$(document).ready(function () {
    $("#loginDialog").hide();
    $("#logged").hide();
    $("#leftPlayerButton").attr("disabled", true);
    $("#rightPlayerButton").attr("disabled", true);
    resetBoard();
    refreshGameModel = setInterval(getModel, 300);
    //setInterval(refreshBoardFromServer, 400);
    //setInterval(refreshPlayersFromServer, 400);
    //checkWin = setInterval(checkPlayersWin, 1000);
    //console.log(checkWin);

});
function refreshLang(data) {
    lang = data;
    $("#loginButton").attr("value", lang("loginButton"));
    $("#title").html(lang("title"));
    $("#nameLbl").html(lang("nameLbl"));
    $("#passwordLbl").html(lang("passwordLbl"));
    $("#signInButton").attr("value", lang("signInButton"));
    $("#logOutButton").attr("value", lang("logOutButton"));
    $("#resetButton").attr("value", lang("resetButton"));
    $("#boardSizeLbl").html(lang("boardSizeLbl"));
    $("#numberForWinLbl").html(lang("numberForWinLbl"));
    if (loginResponse != "loginError") {
        $("#loggedUser").html(lang("onLine") + loginUser);
    } else {
        $("#loggedUser").html(lang(loginResponse));
    }

}
function resetModel() {
    loginModel.userName = "";
    loginModel.userPassword = "";
    }
function loginClick() {
    $("#loginDialog").show();    
}
function errorResponse() {
    alert(lang("serverNotResponsed"));
}
function logIn() {
    refreshLoginModel();
    $.ajax({
        url: "http://localhost:50795/loginUser.ashx?name=" + loginModel.userName + "&password=" + loginModel.userPassword,
        success: refreshUserLogged,
        error: errorResponse
    })
}
function refreshUserLogged(data) {
    $("#logged").show();
    loginResponse = data;
    if (data != "loginError") {
        loginUser = loginResponse;
        $("#loginDialog").hide();
        $("#loggedUser").html(lang("onLine") + loginUser);
        $("#leftPlayerButton").attr("disabled", false);
        $("#rightPlayerButton").attr("disabled", false);
    }
    else {
        $("#loggedUser").html(lang(loginResponse));
    }
}
function refreshLoginModel() {
    loginModel.userName = $("#name").val();
    loginModel.userPassword = $("#password").val();
}
function logOut() {
    $("#loginDialog").hide();
    $("#logged").hide();
    $("#leftPlayerButton").attr("disabled", true);
    $("#rightPlayerButton").attr("disabled", true);
    loginUser = "";
}
function resetBoard() {
    var newBoardSize = $("#boardSize").val();
    var newNumberForWin = $("#numberForWin").val();
    $.ajax({
        url: "http://localhost:50795/reset.ashx?boardSize=" + newBoardSize + "&numberForWin=" + newNumberForWin,
    })
}
function getModel() {
    $.ajax({
        url: "http://localhost:50795/getModel.ashx",
        success: onSuccess,
    })
}
function onSuccess(data) {
    gameModel = data;
    refreshGame();
}
function refreshGame() {
    refreshBoardFromGameModel();
    refreshPlayers();
    refreshWinPlayer();
}
function refreshBoardFromGameModel() {
    if (boardSize != gameModel.BoardSize) {
        boardSize = gameModel.BoardSize;
        $("#board").html("");
        var tableBoard = "";
        for (var row = 1; row <= boardSize; row++) {
            var tr = "<tr>";
            for (var col = 1; col <= boardSize; col++) {
                var td = "<td><div id='board" + row + "-" + col + "' class='boardCell' onclick='clickCell(" + row + "," + col + ")'></div></td>";
                tr += td;
            }
            tr += "</tr>"
            tableBoard += tr;
        }
        $("#board").html(tableBoard);
        boardModel = new Array(boardSize * boardSize);
    }
    boardModel = gameModel.Board;
    refreshBoard();
}
function refreshPlayers() {
    $("#leftPlayerButton").attr("value", gameModel.Lplayer);
    $("#rightPlayerButton").attr("value", gameModel.Rplayer);
}
function refreshWinPlayer() {
    if (gameModel.WinPlayer != null) {
        if (winAlerted == false) {
            winAlerted = true;
            alert(lang("wonPlayer") + gameModel.WinPlayer + lang("Congratulations"));
        }       
    } else {
        winAlerted = false;
    }
}
function leftPlayerClick() {
    $.ajax({
        url: "http://localhost:50795/leftPlayerSet.ashx?leftPlayer=" + loginUser,
        success: onLeftPlayerSuccess

    })
}
function onLeftPlayerSuccess(data) {
    alert(lang(data));
}
function rightPlayerClick() {
    $.ajax({
        url: "http://localhost:50795/rightPlayerSet.ashx?rightPlayer=" + loginUser,
        success: onRightPlayerSuccess

    })
}
function onRightPlayerSuccess(data) {
    alert(lang(data));
}
function clickCell(row, col) {
    $.ajax({
        url: "http://localhost:50795/playerClick.ashx?row=" + row + "&col=" + col + "&playerClick=" + loginUser,
        success: onPlayerClickSuccess,
       
    })
}
function onPlayerClickSuccess(data) {
    if (data != "") {
        alert(lang(data));
    }
}
function refreshBoard() {
    for (row = 1 ; row <= boardSize ; row++) {
        for (col = 1 ; col <= boardSize ; col++) {
            var index = (boardSize * (row - 1) + col);
            var color = boardModel[index - 1];
            if (color == "g") {
                $("#board" + row + "-"+ col).addClass("boardCellGreen");
            } else if (color == "o") {
                $("#board" + row + "-" + col).addClass("boardCellOrange");
            } else {
                $("#board" + row + "-" + col).removeClass("boardCellGreen");
                $("#board" + row + "-" + col).removeClass("boardCellOrange");
            }
        }
    }
}

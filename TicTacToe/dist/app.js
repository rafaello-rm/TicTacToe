var gameList = [];
var gameModel = {};
var loginModel = {};
var loginResponse = "";
var loginUser = null;
var boardSize = 5;
var boardModel = new Array(boardSize * boardSize);
var playersOnGame = ["", ""];
var refreshGameModel;
var refreshListGame;
var winAlerted = false;
var idGame = 0;

var en = i18n.create({
    values: {
        "loginButton": "login", "title": "Tic Tac Toe", "nameLbl": "user name: ", "passwordLbl": "password",
        "signInButton": "sign in", "logOutButton": "log Out", "resetButton": "start/reset", "boardSizeLbl": "board size",
        "numberForWinLbl": "number for Win",
        "loginError": "incorrect username or password", "onLine": "online: ", "wonPlayer": "Won player ",
        "Congratulations": "Congratulations on winning!\n", "YouAreOrange": "You are already in the game as a player orange",
        "joinGreen": "You joined the game as a player green", "YouAreGreen": "You are already in the game as a player green",
        "joinOrange": "You joined the game as a player orange", "colorBusy": "This color is already busy",
        "mustLoginAndJoin": "you must first log in and join the game", "mustJoin": "you must first join the game",
        "wait": "wait for his move", "areaOccupied": "this area is already occupied", "serverNotResponsed": "server not responsed",
        "gameList": "List of Games:", "normalGame": "Normal", "fallGame": "The Falling Cubes", "randomGame": "Random Cubes",
        "modeNormalButton": "game normal", "modeRandomButton": "Random Cubes",
        "modeFallButton": "the falling cubes", "addGameLbl": "add game", "free": "free", "size": "size", "continue?": "Do you want to play again?"
    }
})
var pl = i18n.create({
    values: {
        "loginButton": "logowanie", "title": "Kółko i Krzyżyk", "nameLbl": "nazwa użytkownika: ", "passwordLbl": "hasło",
        "signInButton": "zaloguj", "logOutButton": "wyloguj", "resetButton": "rozpocznij/kasuj", "boardSizeLbl": "rozmiar planszy",
        "numberForWinLbl": "liczba do wygranej",
        "loginError": "niepoprawna nazwa użytkowanika lub hasło", "onLine": "zalogowany: ", "wonPlayer": "Wygrał gracz ",
        "Congratulations": "Gratuluję wygranej!\n", "YouAreOrange": "Dołączyłeś już do gry jako gracz pomarańczowy",
        "joinGreen": "Dołączyłeś do gry jako gracz zielony", "YouAreGreen": "Dołączyłeś już do gry jako gracz zielony",
        "joinOrange": "Dołączyłeś do gry jako gracz pomarańczowy", "colorBusy": "Ten kolor jest już zajęty",
        "mustLoginAndJoin": "trzeba się najpierw zalogować i dołączyć do gry", "mustJoin": "musisz najpierw dołączyć do gry",
        "wait": "zaczekaj na swój ruch", "areaOccupied": "to pole jest już zajęte", "serverNotResponsed": "serwer nie odpowiedział",
        "gameList": "Lisa gier:", "normalGame": "Normalna", "fallGame": "Spadające Kostki", "randomGame": "Losowe Kostki",
        "modeNormalButton": "gra normalna", "modeRandomButton": "Losowe Kostki",
        "modeFallButton": "spadające kostki", "addGameLbl": "dodaj grę", "free": "wolny", "size": "rozmiar", "continue?": "Czy chcesz zagrać jeszcze raz?"
    }
})
var es = i18n.create({
    values: {
        "loginButton": "login", "title": "Tic Tac Toe", "nameLbl": "nombre de usuario: ", "passwordLbl": "contraseña",
        "signInButton": "iniciar la sesión", "logOutButton": "log", "resetButton": "iniciar / borrar", "boardSizeLbl": "tamaño del tablero",
        "numberForWinLbl": "Número de ganar",
        "loginError": "nombre de usuario o contraseña incorrecta", "onLine": "en línea: ", "wonPlayer": "ganó el jugador ",
        "Congratulations": "Felicitaciones por ganar!\n", "YouAreOrange": "Ya estás en el juego como un jugador de naranja",
        "joinGreen": "Que se unió al juego como un jugador verde", "YouAreGreen": "Ya estás en el juego como un jugador verde",
        "joinOrange": "Que se unió al juego como un jugador de naranja", "colorBusy": "Este color ya está ocupado",
        "mustLoginAndJoin": "primero debe iniciar sesión en el juego y unirse", "mustJoin": "que primero debe unirse al juego",
        "wait": "esperar a que su movimiento", "areaOccupied": "Esta área ya está ocupado", "serverNotResponsed": "Servidor no respondió",
        "gameList": "Lista de juegos:", "normalGame": "Largo", "fallGame": "Los cubos que caen", "randomGame": "Dados al Azar",
        "modeNormalButton": "juego largo", "modeRandomButton": "Dados al Azar",
        "modeFallButton": "los cubos que caen", "addGameLbl": "agregar juego", "free": "gratis", "size": "tamaño", "continue?": "Quieres jugar de nuevo?"
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
    refreshListGame = setInterval(getList, 1000);
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
    $("#addGameLbl").html(lang("addGameLbl"));
    $("#modeNormalButton").attr("value", lang("modeNormalButton"));
    $("#modeFallButton").attr("value", lang("modeFallButton"));
    $("#modeRandomButton").attr("value", lang("modeRandomButton"));
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
        url: "http://localhost:50795/reset.ashx?boardSize=" + newBoardSize + "&numberForWin=" + newNumberForWin + "&idGame=" + idGame,
    })
}
function getModel() {
    $.ajax({
        url: "http://localhost:50795/getModel.ashx?idGame=" + idGame,
        success: onGetModelSuccess,
    })
}
function onGetModelSuccess(data) {
    gameModel = data;
    refreshGame();
}
function getList() {
    $.ajax({
        url: "http://localhost:50795/getListGame.ashx?playerId=" + loginUser,
        success: OnGetListGameSuccess,
    })
}
function OnGetListGameSuccess(data) {
    //var oldList = String(gameList);
    //if (String(data) != oldList) {
    //    gameList = data;
    //    refreshGameList();
    //}
    gameList = data;
    refreshGameList();
}
function refreshGameList() {
    if (idGame >= gameList.length) {
        idGame = 0;
    }
    
    var divGameList = $("#gameList");
    divGameList.html("");
    divGameList.append("<p> <label id='gameListLbl'>" + lang('gameList') + "</label> </p>")
    for (i = 0; i < gameList.length; i++) {
        if (gameList[i].LeftPlayer == "") {
            var lPlayerOnList = lang("free");
        } else {
            var lPlayerOnList = gameList[i].LeftPlayer;
        }
        if (gameList[i].RightPlayer == "") {
            var rPlayerOnList = lang("free");
        } else {
            var rPlayerOnList = gameList[i].RightPlayer;
        }
        if (idGame == i) {
            var rowGameList = "<p> <input id='remove" + i + "' type='button' value='del' onclick='removeGame(" + i + ")'/>" +
                "<input type='button' class='buttonGameSet' id='game" + i + "' onclick='setGame(" + i + ")' value='" +
                lang(gameList[i].GameName) + "'/>" + lPlayerOnList + " - " + rPlayerOnList + " " + lang("size") + ": " + gameList[i].GameSize + "</p>";
        } else {
            var rowGameList = "<p> <input id='remove" + i + "' type='button' value='del' onclick='removeGame(" + i + ")'/>" +
                "<input type='button' class='buttonGame' id='game" + i + "' onclick='setGame(" + i + ")' value='" +
                lang(gameList[i].GameName) + "'/>" + lPlayerOnList + " - " + rPlayerOnList + " " + lang("size") + ": " + gameList[i].GameSize + "</p>";
        }
        $("#game" + idGame).addClass("setGreen");
        divGameList.append(rowGameList);
        if (gameList[i].IsOwner != true) {
            $("#remove" + i).attr("disabled", true);
        }
    }
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
            if (gameModel.WinPlayer == loginUser) {
                if (confirm(lang("Congratulations") + lang("continue?"))) {
                    renewBoard(idGame);
                } else {
                    removeGame(idGame);
                }
            } else {
                alert(lang("wonPlayer") + gameModel.WinPlayer);
            }      
        }       
    } else {
        winAlerted = false;
    }
}
function leftPlayerClick() {
    $.ajax({
        url: "http://localhost:50795/leftPlayerSet.ashx?leftPlayer=" + loginUser + "&idGame=" + idGame,
        success: onLeftPlayerSuccess

    })
}
function onLeftPlayerSuccess(data) {
    alert(lang(data));
}
function rightPlayerClick() {
    $.ajax({
        url: "http://localhost:50795/rightPlayerSet.ashx?rightPlayer=" + loginUser + "&idGame=" + idGame,
        success: onRightPlayerSuccess

    })
}
function onRightPlayerSuccess(data) {
    alert(lang(data));
}
function clickCell(row, col) {
    $.ajax({
        url: "http://localhost:50795/playerClick.ashx?row=" + row + "&col=" + col + "&playerClick=" + loginUser + "&idGame=" + idGame,
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
function AddGame(gameMode) {
    $.ajax({
        url: "http://localhost:50795/addGame.ashx?gameType=" + gameMode +"&playerId=" + loginUser,
    })
    //window.setTimeout(setGame(gameList.length), 3000);
    //window.setTimeout(resetBoard(), 3000);
}
function setGame(id) {
    idGame = id;
    refreshGameList();
}
function removeGame(idToRemove) {
    $.ajax({
        url: "http://localhost:50795/removeGame.ashx?idToRemove=" + idToRemove,
    })
}
function renewBoard(idToRenew) {
    $.ajax({
        url: "http://localhost:50795/renewBoard.ashx?idToRenew=" + idToRenew,
    })
}
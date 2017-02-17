var gameModel = {};
var loginModel = {};
var loginResponse = "";
var loginUser = "";
var boardModel = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
var playersOnGame = ["", ""];
var refreshGameModel;

var en = i18n.create({
    values: {
        "loginButton": "login", "title": "Tic Tac Toe", "nameLbl": "user name: ", "passwordLbl": "password",
        "signInButton": "sign in", "logOutButton": "log Out", "resetButton": "start/reset",
        "loginError": "incorrect username or password", "onLine": "online: ", "wonPlayer": "Won player ",
        "Congratulations": ". Congratulations!", "YouAreOrange": "You are already in the game as a player orange",
        "joinGreen": "You joined the game as a player green", "YouAreGreen": "You are already in the game as a player green",
        "joinOrange": "You joined the game as a player orange", "colorBusy": "This color is already busy",
        "mustLoginAndJoin": "you must first log in and join the game", "mustJoin": "you must first join the game",
        "wait": "wait for his move", "areaOccupied": "this area is already occupied"
    }
})
var pl = i18n.create({
    values: {
        "loginButton": "logowanie", "title": "Kółko i Krzyżyk", "nameLbl": "nazwa użytkownika: ", "passwordLbl": "hasło",
        "signInButton": "zaloguj", "logOutButton": "wyloguj", "resetButton": "rozpocznij/kasuj",
        "loginError": "niepoprawna nazwa użytkowanika lub hasło", "onLine": "zalogowany: ", "wonPlayer": "Wygrał gracz ",
        "Congratulations": ". Gratulacje!", "YouAreOrange": "Dołączyłeś już do gry jako gracz pomarańczowy",
        "joinGreen": "Dołączyłeś do gry jako gracz zielony", "YouAreGreen": "Dołączyłeś już do gry jako gracz zielony",
        "joinOrange": "Dołączyłeś do gry jako gracz pomarańczowy", "colorBusy": "Ten kolor jest już zajęty",
        "mustLoginAndJoin": "trzeba się najpierw zalogować i dołączyć do gry", "mustJoin": "musisz najpierw dołączyć do gry",
        "wait": "zaczekaj na swój ruch", "areaOccupied": "to pole jest już zajęte"
    }
})
var es = i18n.create({
    values: {
        "loginButton": "login", "title": "Tic Tac Toe", "nameLbl": "nombre de usuario: ", "passwordLbl": "contraseña",
        "signInButton": "iniciar la sesión", "logOutButton": "log", "resetButton": "iniciar / borrar",
        "loginError": "nombre de usuario o contraseña incorrecta", "onLine": "en línea: ", "wonPlayer": "ganó el jugador ",
        "Congratulations": ". Felicitaciones!", "YouAreOrange": "Ya estás en el juego como un jugador de naranja",
        "joinGreen": "Que se unió al juego como un jugador verde", "YouAreGreen": "Ya estás en el juego como un jugador verde",
        "joinOrange": "Que se unió al juego como un jugador de naranja", "colorBusy": "Este color ya está ocupado",
        "mustLoginAndJoin": "primero debe iniciar sesión en el juego y unirse", "mustJoin": "que primero debe unirse al juego",
        "wait": "esperar a que su movimiento", "areaOccupied": "Esta área ya está ocupado"
    }
})
var lang = pl;


$(document).ready(function () {
    $("#loginDialog").hide();
    $("#logged").hide();
    $("#leftPlayerButton").attr("disabled", true);
    $("#rightPlayerButton").attr("disabled", true);
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
    alert("serwer nie odpowiedział");
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
    var divUserLogged = $("#userLogged");
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
function resetButton() {
    $.ajax({
        url: "http://localhost:50795/reset.ashx"
    })
    refreshGameModel = setInterval(getModel, 300);
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
    boardModel = gameModel.Board;
    refreshBoard();
}
function refreshPlayers() {
    $("#leftPlayerButton").attr("value", gameModel.Lplayer);
    $("#rightPlayerButton").attr("value", gameModel.Rplayer);
}
function refreshWinPlayer() {
    if (gameModel.WinPlayer != null) {
        alert(lang("wonPlayer") + gameModel.WinPlayer + lang("Congratulations"));
        clearInterval(refreshGameModel);
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
    var index = (5 * (row - 1) + col);
    $.ajax({
        url: "http://localhost:50795/playerClick.ashx?index=" + index + "&playerClick=" + loginUser,
        success: onPlayerClickSuccess,
       
    })
}
function onPlayerClickSuccess(data) {
    if (data != "") {
        alert(lang(data));
    }
}
function refreshBoard() {
    for (row = 1 ; row <= 5 ; row++) {
        for (col = 1 ; col <= 5 ; col++) {
            var index = (5 * (row - 1) + col);
            var color = boardModel[index - 1];
            if (color == "g") {
                $("#board" + row + col).addClass("boardCellGreen");
            } else if (color == "o") {
                $("#board" + row + col).addClass("boardCellOrange");
            } else {
                $("#board" + row + col).removeClass("boardCellGreen");
                $("#board" + row + col).removeClass("boardCellOrange");
            }
        }
    }
}

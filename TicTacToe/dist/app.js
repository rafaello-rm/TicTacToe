var gameModel = {};
var loginModel = {};
var loginUser = "";
var boardModel = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
var playersOnGame = ["", ""];
var refreshGameModel;
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
    
    loginUser = data;
    if (data != "niepoprawna nazwa użytkownika lub hasło") {
        $("#loginDialog").hide();
        $("#loggedUser").html("zalogowany: " + data);
        $("#leftPlayerButton").attr("disabled", false);
        $("#rightPlayerButton").attr("disabled", false);
    }
    else {
        $("#loggedUser").html(data);
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
        alert("Wygrał gracz " + gameModel.WinPlayer);
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
    alert(data);
}
function rightPlayerClick() {
    $.ajax({
        url: "http://localhost:50795/rightPlayerSet.ashx?rightPlayer=" + loginUser,
        success: onRightPlayerSuccess

    })
}
function onRightPlayerSuccess(data) {
    alert(data);
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
        alert(data);
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
function onGetBoardSuccess(data) {
    //console.log(data);
    boardModel = data.split(";");
    refreshBoard();
}
function refreshBoardFromServer() {
    $.ajax({
        url: "http://localhost:50795/getBoard.ashx",
        success: onGetBoardSuccess,

    })
}
function refreshPlayersFromServer() {
    $.ajax({
        url: "http://localhost:50795/getPlayers.ashx",
        success: onGetPlayersSuccess,

    })
}
function onGetPlayersSuccess(data) {
    playersOnGame = data.split(";");
    $("#leftPlayerButton").attr("value", playersOnGame[0]);
    $("#rightPlayerButton").attr("value", playersOnGame[1]);
    //console.log(data);
}
function checkPlayersWin() {
    $.ajax({
        url: "http://localhost:50795/checkPlayersWin.ashx",
        success: onCheckPlayersWin,
    })
}
function onCheckPlayersWin(data) {
    if (data != "") {
        alert(data);
        clearInterval(checkWin);
    }
}
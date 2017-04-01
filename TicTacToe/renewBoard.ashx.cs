using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for renewBoard
    /// </summary>
    public class renewBoard : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var strIdGame = context.Request.Params["idToRenew"];
            int idGame;
            int.TryParse(strIdGame, out idGame);
            TicTacToeModel.Service.GetGame(idGame).RenewBoard();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
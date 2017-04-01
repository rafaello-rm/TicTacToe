using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for leftPlayerSet
    /// </summary>
    public class leftPlayerSet : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var strIdGame = context.Request.Params["idGame"];
            int idGame;
            int.TryParse(strIdGame, out idGame);
            var response = TicTacToeModel.Service.GetGame(idGame).SetLeftPlayer(context.Request.Params["leftPlayer"]);

            context.Response.ContentType = "text/plain";

            context.Response.Write(response);
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
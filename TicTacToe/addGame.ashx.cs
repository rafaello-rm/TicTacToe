using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for addGame
    /// </summary>
    public class addGame : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            TicTacToeModel.Service.AddGame(context.Request.Params["gameType"], context.Request.Params["playerId"]);
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
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
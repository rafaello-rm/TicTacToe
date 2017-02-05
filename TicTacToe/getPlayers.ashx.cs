using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for getPlayers
    /// </summary>
    public class getPlayers : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(TicTacToeModel.LeftPlayer + ";" + TicTacToeModel.RightPlayer);
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
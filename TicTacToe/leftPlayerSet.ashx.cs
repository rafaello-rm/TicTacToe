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
            var response = TicTacToeModel.Service.GetGame(0).SetLeftPlayer(context.Request.Params["leftPlayer"]);

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
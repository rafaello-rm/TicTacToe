using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for rightPlayerSet
    /// </summary>
    public class rightPlayerSet : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var response = TicTacToeModel.Service.SetRightPlayer(context.Request.Params["rightPlayer"]);

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
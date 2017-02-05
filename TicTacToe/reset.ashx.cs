using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for reset
    /// </summary>
    public class reset : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            for (var i = 0; i <= 24; i++)
            {
                TicTacToeModel.Model[i] = ' ';
            }
            context.Response.ContentType = "text/plain";
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
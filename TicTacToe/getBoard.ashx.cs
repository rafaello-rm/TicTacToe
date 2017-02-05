using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for getBoard
    /// </summary>
    public class getBoard : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //var result = TicTacToeModel.Model.Join(';');
            for (var i = 0; i < TicTacToeModel.Model.Count; i++)
            {
                context.Response.Write(TicTacToeModel.Model[i]);
                context.Response.Write(";");
            }
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
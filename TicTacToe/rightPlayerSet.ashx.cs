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
            var response = "";
            if (TicTacToeModel.RightPlayer == "") {
                if (context.Request.Params["rightPlayer"] == TicTacToeModel.LeftPlayer) {
                    response = "YouAreGreen";
                } else {
                    TicTacToeModel.RightPlayer = context.Request.Params["rightPlayer"];
                    response = "joinOrange";
                }
                
            } else {
                response = "colorBusy";
            }

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
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
            var response = "";
            if (TicTacToeModel.LeftPlayer == "") {
                if (context.Request.Params["leftPlayer"] == TicTacToeModel.RightPlayer) {
                    response = "YouAreOrange";
                } else {
                    TicTacToeModel.LeftPlayer = context.Request.Params["leftPlayer"];
                    response = "joinGreen";
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
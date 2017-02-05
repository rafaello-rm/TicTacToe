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
                    response = "Dołączyłeś już do gry jako gracz zielony";
                } else {
                    TicTacToeModel.RightPlayer = context.Request.Params["rightPlayer"];
                    response = "Dołączyłeś do gry jako gracz pomarańczowy";
                }
                
            } else {
                response = "Ten kolor jest już zajęty";
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
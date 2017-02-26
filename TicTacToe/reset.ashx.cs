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
            var strBoardSize = context.Request.Params["boardSize"];
            int boardSize;
            int.TryParse(strBoardSize, out boardSize);

            var strNumberForWin = context.Request.Params["numberForWin"];
            int numberForWin;
            int.TryParse(strNumberForWin, out numberForWin);

            TicTacToeModel.Service.GetGame(0).Reset(boardSize, numberForWin);

            context.Response.ContentType = "text/plain";
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
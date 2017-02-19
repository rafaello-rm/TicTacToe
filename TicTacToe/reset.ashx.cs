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
            TicTacToeModel.BoardSize = boardSize;

            var strNumberForWin = context.Request.Params["numberForWin"];
            int numberForWin;
            int.TryParse(strNumberForWin, out numberForWin);
            TicTacToeModel.NumberForWin = numberForWin;

            TicTacToeModel.Model = new List<char>();
            for (var i = 0; i < boardSize * boardSize; i++)
            {
                TicTacToeModel.Model.Add(' ');
            }
            TicTacToeModel.LastClickPlayer = "";
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
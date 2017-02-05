using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for checkPlayersWin
    /// </summary>
    public class checkPlayersWin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (CheckPlayerWin('g') == true) {
                context.Response.Write(TicTacToeModel.LeftPlayer + " wygrał");
            } else {
                context.Response.Write("");
            }
            if (CheckPlayerWin('o') == true) {
                context.Response.Write(TicTacToeModel.RightPlayer + " wygrał");
            }
            else {
                context.Response.Write("");
            }

        }

        public bool CheckPlayerWin(char colour)
        {
            bool result = false;
            int counter;
            for (var row = 0; row <= 20; row += 5) //check rows
            {
                counter = 0;
                for (var i = row; i <= row + 4; i++)
                {
                    if (TicTacToeModel.Model[i] == colour)
                    {
                        counter++;
                    } else
                    {
                        counter = 0;
                    }
                }
                if (counter == 3)
                {
                    result = true;
                }        
            }
            //for (var col = 0; col <= 4; col++) //check columns
            //{
            //    counter = 0;
            //    for (var i = col; i <= 24; i += 5)
            //    {
            //        if (TicTacToeModel.Model[i] == colour)
            //        {
            //            counter++;
            //        } else
            //        {
            //            counter = 0;
            //        }
            //    }
            //    if (counter == 3)
            //    {
            //        result = true;
            //    }
            //}

            //counter = 0;
            //for (var i = 10; i <= 22; i += 6) //check diagonals '\\\\\'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    } else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 5; i <= 23; i += 6) //check diagonals '\\\\\'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 0; i <= 24; i += 6) //check diagonals '\\\\\'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 1; i <= 19; i += 6) //check diagonals '\\\\\'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 2; i <= 14; i += 6) //check diagonals '\\\\\'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 2; i <= 10; i += 4) //check diagonals '/////'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 3; i <= 15; i += 4) //check diagonals '/////'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 4; i <= 20; i += 4) //check diagonals '/////'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 9; i <= 21; i += 4) //check diagonals '/////'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            //counter = 0;
            //for (var i = 14; i <= 22; i += 4) //check diagonals '/////'
            //{
            //    if (TicTacToeModel.Model[i] == colour)
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //if (counter == 3)
            //{
            //    result = true;
            //}
            return result;
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
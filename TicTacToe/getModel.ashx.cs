using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for getModel
    /// </summary>
    public class getModel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var instancja = new GameModel();
            instancja.Board = TicTacToeModel.Model;
            instancja.Lplayer = TicTacToeModel.LeftPlayer;
            instancja.Rplayer = TicTacToeModel.RightPlayer;
            instancja.LastClickPlayer = TicTacToeModel.LastClickPlayer;
            instancja.BoardSize = TicTacToeModel.BoardSize;

            

            if (CheckPlayerWin('g') == true)
            {
                instancja.WinPlayer = instancja.Lplayer;
            }
            else
            {
                if (CheckPlayerWin('o') == true)
                {
                    instancja.WinPlayer = instancja.Rplayer;
                }
                else
                {
                    instancja.WinPlayer = null;
                }
            }

            string modelAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(instancja);
            context.Response.ContentType = "application/json";
            context.Response.Write(modelAsJson);
        }



        public bool CheckPlayerWin(char colour)
        {
            bool result = false;
            int counter;
            var size = TicTacToeModel.BoardSize;
            for (var i = 0; i < (size * size); i += size) //check rows
            {
                counter = 0;
                for (var j = i; j < (i + size); j++)
                {
                    if (TicTacToeModel.Model[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == TicTacToeModel.NumberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = 0; i < size; i++) //check columns
            {
                counter = 0;
                for (var j = i; j <= (size * (size - 1)) + i; j += size)
                {
                    if (TicTacToeModel.Model[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == TicTacToeModel.NumberForWin)
                    {
                        result = true;
                    }
                }
            }

            for (var i = 0; i < size - 1; i++) //check diagonals \\\
            {
                counter = 0;
                for (var j = i; j < (size * size) - (size * i); j += (size + 1))
                {
                    if (TicTacToeModel.Model[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == TicTacToeModel.NumberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = size; i <= (size * size) - size; i += size) //check diagonals\\\
            {
                counter = 0;
                for (var j = i; j < size * size; j += (size + 1))
                {
                    if (TicTacToeModel.Model[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == TicTacToeModel.NumberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = 0; i < size; i++)
            {
                counter = 0;
                for (var j = i; j <= i * size; j += (size - 1))
                {
                    if (TicTacToeModel.Model[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == TicTacToeModel.NumberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = (size * 2) - 1; i < size * size; i += size)
            {
                counter = 0;
                for (var j = i; j < size * size; j += (size - 1))
                {
                    if (TicTacToeModel.Model[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == TicTacToeModel.NumberForWin)
                    {
                        result = true;
                    }
                }
            }
            
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
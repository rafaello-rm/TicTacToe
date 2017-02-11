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
    for (var row = 0; row <= 20; row += 5) //check rows
    {
        counter = 0;
        for (var i = row; i <= row + 4; i++)
        {
            if (TicTacToeModel.Model[i] == colour)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
            if (counter == 3)
            {
                result = true;
            }
        }
    }
    for (var col = 0; col <= 4; col++) //check columns
    {
        counter = 0;
        for (var i = col; i <= 24; i += 5)
        {
            if (TicTacToeModel.Model[i] == colour)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
            if (counter == 3)
            {
                result = true;
            }
        }
    }

    counter = 0;
    for (var i = 10; i <= 22; i += 6) //check diagonals '\\\\\'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 5; i <= 23; i += 6) //check diagonals '\\\\\'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 0; i <= 24; i += 6) //check diagonals '\\\\\'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 1; i <= 19; i += 6) //check diagonals '\\\\\'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 2; i <= 14; i += 6) //check diagonals '\\\\\'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 2; i <= 10; i += 4) //check diagonals '/////'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 3; i <= 15; i += 4) //check diagonals '/////'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 4; i <= 20; i += 4) //check diagonals '/////'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 9; i <= 21; i += 4) //check diagonals '/////'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
        }
    }
    counter = 0;
    for (var i = 14; i <= 22; i += 4) //check diagonals '/////'
    {
        if (TicTacToeModel.Model[i] == colour)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if (counter == 3)
        {
            result = true;
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
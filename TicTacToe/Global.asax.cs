using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TicTacToe
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            TicTacToeModel.LeftPlayer = "";
            TicTacToeModel.RightPlayer = "";
            TicTacToeModel.LastClickPlayer = "";
            TicTacToeModel.BoardSize = 5;
            TicTacToeModel.NumberForWin = 3;
            TicTacToeModel.Model = new List<char>();
            for (var i = 0; i < TicTacToeModel.BoardSize * TicTacToeModel.BoardSize; i++)
            {
                TicTacToeModel.Model.Add(' ');
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
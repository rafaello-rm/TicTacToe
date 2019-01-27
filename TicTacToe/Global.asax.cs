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
            var modelAllUsers = new List<ChatUser>();
            var agaUser = new ChatUser();
            var nikaUser = new ChatUser();

            agaUser.Login = "aga";
            nikaUser.Login = "nika";

            agaUser.Contacts.Add(nikaUser.Login);

            TicTacToeModel.Service = new service.TicTacToeListService();
            //TicTacToeModel.Service.AddGame("normal", string.Empty);
            TicTacToeModel.Service.OpenGameData();
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
        public class ChatUser
        {
            public ChatUser()
            {
                Login = string.Empty;
                Contacts = new List<string>();
            }

            public string Login { get; set; }
            public List<string> Contacts { get; set; }

        }
    }
}
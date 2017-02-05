using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for loginUser
    /// </summary>
    public class loginUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var user = context.Request.Params["name"];
            var password = context.Request.Params["password"];
            var isLogged = canBeLoggedIn(user, password);
            context.Response.ContentType = "text/plain";
            if (isLogged == true)
            {                
                context.Response.Write(user);
            } else
            {
                context.Response.Write("niepoprawna nazwa użytkownika lub hasło");
            }
            
        }

        public bool canBeLoggedIn(string user, string password)
        {
            if (user == "Rafał" & password == "123")
                return true;
            else
                if (user == "Krzysztof" & password == "123")
                return true;
            else
                if (user == "nika" & password == "123")
                return true;
            else
                if (user == "aga" & password == "123")
                return true;
            else
            return false;
            

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
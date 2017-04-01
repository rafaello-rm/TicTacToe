using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for removeGame
    /// </summary>
    public class removeGame : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var strIdToRemove = context.Request.Params["idToRemove"];
            int idToRemove;
            int.TryParse(strIdToRemove, out idToRemove);

            TicTacToeModel.Service.RemoveGame(idToRemove);
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
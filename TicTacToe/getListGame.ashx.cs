using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for getListGame
    /// </summary>
    public class getListGame : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var gameList = TicTacToeModel.Service.GetList(context.Request.Params["playerId"]);
            string modelAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(gameList);
            context.Response.ContentType = "application/json";
            context.Response.Write(modelAsJson);
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
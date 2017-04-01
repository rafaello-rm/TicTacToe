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
            var strIdGame = context.Request.Params["idGame"];
            int idGame;
            int.TryParse(strIdGame, out idGame);
            var game = TicTacToeModel.Service.GetGame(idGame);
            var instancja = game.GetModel();
            string modelAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(instancja);
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
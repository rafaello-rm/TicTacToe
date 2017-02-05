﻿using System;
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
            string modelAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(TicTacToeModel.Model);
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
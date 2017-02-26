using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    /// <summary>
    /// Summary description for playerClick
    /// </summary>
    public class playerClick : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var strRow = context.Request.Params["row"];
            int intRow;
            int.TryParse(strRow, out intRow);

            var strCol = context.Request.Params["col"];
            int intCol;
            int.TryParse(strCol, out intCol);

            var playerClick = context.Request.Params["playerClick"];
            var response = TicTacToeModel.Service.MarkCell(playerClick, intRow, intCol);
            

            context.Response.ContentType = "text/plain";
            context.Response.Write(response);
                           
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
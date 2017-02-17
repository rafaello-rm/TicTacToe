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
            var strIndex = context.Request.Params["index"];
            int intIndex;
            int.TryParse(strIndex, out intIndex);
            var playerClick = context.Request.Params["playerClick"];

            context.Response.ContentType = "text/plain";

            if (playerClick == "") {
                context.Response.Write("mustLoginAndJoin");
            } else
            {
                if (playerClick != "" && playerClick != TicTacToeModel.LeftPlayer && playerClick != TicTacToeModel.RightPlayer)
                {
                    context.Response.Write("mustJoin");
                }
                if (playerClick == TicTacToeModel.LeftPlayer) {
                    if (playerClick == TicTacToeModel.LastClickPlayer) {
                        context.Response.Write("wait");
                    } else {
                        if (TicTacToeModel.Model[intIndex - 1] != ' ') {
                            context.Response.Write("areaOccupied");
                        } else {
                            TicTacToeModel.Model[intIndex - 1] = 'g';
                            TicTacToeModel.LastClickPlayer = playerClick;
                        }                        
                    }                    
                
                }
                if (playerClick == TicTacToeModel.RightPlayer) {
                    if (playerClick == TicTacToeModel.LastClickPlayer) {
                        context.Response.Write("wait");
                    } else {
                        if (TicTacToeModel.Model[intIndex - 1] != ' ') {
                            context.Response.Write("areaOccupied");
                        }
                        else {
                            TicTacToeModel.Model[intIndex - 1] = 'o';
                            TicTacToeModel.LastClickPlayer = playerClick;
                        }
                    }
                }
            }
            
            
                           
        }
        public bool CheckLeftPlayerWin()
        {
            if ((TicTacToeModel.Model[0] == 'g' && TicTacToeModel.Model[1] == 'g' && TicTacToeModel.Model[2] == 'g') || (TicTacToeModel.Model[3] == 'g' && TicTacToeModel.Model[4] == 'g' && TicTacToeModel.Model[5] == 'g') || (TicTacToeModel.Model[6] == 'g' && TicTacToeModel.Model[7] == 'g' && TicTacToeModel.Model[8] == 'g') || (TicTacToeModel.Model[0] == 'g' && TicTacToeModel.Model[3] == 'g' && TicTacToeModel.Model[6] == 'g') || (TicTacToeModel.Model[1] == 'g' && TicTacToeModel.Model[4] == 'g' && TicTacToeModel.Model[7] == 'g') || (TicTacToeModel.Model[2] == 'g' && TicTacToeModel.Model[5] == 'g' && TicTacToeModel.Model[8] == 'g') || (TicTacToeModel.Model[0] == 'g' && TicTacToeModel.Model[4] == 'g' && TicTacToeModel.Model[8] == 'g') || (TicTacToeModel.Model[2] == 'g' && TicTacToeModel.Model[4] == 'g' && TicTacToeModel.Model[6] == 'g'))
                return true;
            else
                return false;
        }
        public bool CheckRightPlayerWin()
        {
            if ((TicTacToeModel.Model[0] == 'o' && TicTacToeModel.Model[1] == 'o' && TicTacToeModel.Model[2] == 'o') || (TicTacToeModel.Model[3] == 'o' && TicTacToeModel.Model[4] == 'o' && TicTacToeModel.Model[5] == 'o') || (TicTacToeModel.Model[6] == 'o' && TicTacToeModel.Model[7] == 'o' && TicTacToeModel.Model[8] == 'o') || (TicTacToeModel.Model[0] == 'o' && TicTacToeModel.Model[3] == 'o' && TicTacToeModel.Model[6] == 'o') || (TicTacToeModel.Model[1] == 'o' && TicTacToeModel.Model[4] == 'o' && TicTacToeModel.Model[7] == 'o') || (TicTacToeModel.Model[2] == 'o' && TicTacToeModel.Model[5] == 'o' && TicTacToeModel.Model[8] == 'o') || (TicTacToeModel.Model[0] == 'o' && TicTacToeModel.Model[4] == 'o' && TicTacToeModel.Model[8] == 'o') || (TicTacToeModel.Model[2] == 'o' && TicTacToeModel.Model[4] == 'o' && TicTacToeModel.Model[6] == 'o'))
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
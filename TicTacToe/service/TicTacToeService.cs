using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.service
{
    public class TicTacToeGameService: BaseService, ITicTacToeGameService
    {
        
        public TicTacToeGameService(): base("normal")
        {

        }     
        
        public string MarkCell(string playerId, int row, int col)
        {
            
            int index = (this.gameModel.BoardSize * (row - 1) + col);
            if (playerId == "")
            {
                return "mustLoginAndJoin";
            }
            else
            {
                if (playerId != "" && playerId != this.gameModel.Lplayer && playerId != this.gameModel.Rplayer)
                {
                    return "mustJoin";
                }
                if (playerId == this.gameModel.Lplayer)
                {
                    if (playerId == this.gameModel.LastClickPlayer)
                    {
                        return "wait";
                    }
                    else
                    {
                        if (this.gameModel.Board[index - 1] != ' ')
                        {
                            return "areaOccupied";
                        }
                        else
                        {
                            this.gameModel.Board[index - 1] = 'g';
                            this.gameModel.LastClickPlayer = playerId;
                        }
                    }

                }
                if (playerId == this.gameModel.Rplayer)
                {
                    if (playerId == this.gameModel.LastClickPlayer)
                    {
                        return "wait";
                    }
                    else
                    {
                        if (this.gameModel.Board[index - 1] != ' ')
                        {
                            return "areaOccupied";
                        }
                        else
                        {
                            this.gameModel.Board[index - 1] = 'o';
                            this.gameModel.LastClickPlayer = playerId;   
                        }
                    }
                }
            }
            return "";
        }

        
        
    }
}
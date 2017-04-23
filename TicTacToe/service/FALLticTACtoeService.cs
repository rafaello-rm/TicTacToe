using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.service
{
    public class FallTicTacToeGameService: BaseService, ITicTacToeGameService
    {
        
        public FallTicTacToeGameService() : base("fall")
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
                            for (var i = 0; i < this.gameModel.BoardSize; i++)
                            {
                                var rowIndex = (this.gameModel.BoardSize * ((this.gameModel.BoardSize - i) - 1) + col);
                                if (this.gameModel.Board[rowIndex - 1] == ' ')
                                {
                                    this.gameModel.Board[rowIndex - 1] = 'g';
                                    this.gameModel.LastClickPlayer = playerId;
                                    break;
                                }
                            }
                            
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
                            for (var i = 0; i < this.gameModel.BoardSize; i++)
                            {
                                var rowIndex = (this.gameModel.BoardSize * ((this.gameModel.BoardSize - i) - 1) + col);
                                if (this.gameModel.Board[rowIndex - 1] == ' ')
                                {
                                    this.gameModel.Board[rowIndex - 1] = 'o';
                                    this.gameModel.LastClickPlayer = playerId;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }

        
    }
}
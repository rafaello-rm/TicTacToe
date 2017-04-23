using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.service
{
    public class RandomTicTacToeGameService: BaseService,  ITicTacToeGameService
    {
        public RandomTicTacToeGameService() : base("random")
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
                            RandomMarkCell('g');
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
                            RandomMarkCell('o');
                            this.gameModel.LastClickPlayer = playerId;
                        }
                    }
                }
            }
            return "";
        }

        private void RandomMarkCell (char colour)
        {
            Random rnd = new Random();
            int rndIndex1 = rnd.Next(0, this.gameModel.BoardSize * this.gameModel.BoardSize);
            int rndIndex2 = rnd.Next(0, this.gameModel.BoardSize * this.gameModel.BoardSize);

            if (this.gameModel.Board[rndIndex1] == ' ')
            {
                this.gameModel.Board[rndIndex1] = colour;
            }
            if (this.gameModel.Board[rndIndex2] == ' ')
            {
                this.gameModel.Board[rndIndex2] = colour;
            }

        }

        
    }
}
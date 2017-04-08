using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.service
{
    public class GameData
    {
        protected GameData()
        {

        }
        public GameData(GameModel gameModel, int numberForWin, string gameMode)
        {
            this.GameModel = gameModel;
            this.NumberForWin = numberForWin;
            this.GameMode = gameMode;
        }
        public GameModel GameModel { get; set; }
        public int NumberForWin { get; set; }
        public string GameMode { get; set; }
        public string OwnerId { get; set; }
    }
}
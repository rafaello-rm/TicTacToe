using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.service
{
    public class TicTacToeListService : ITicTacToeListService
    {
        private List<ITicTacToeGameService> gameList = new List<ITicTacToeGameService>();
        public void AddGame(string gameMode, string playerId)
        {
            ITicTacToeGameService service;

            if (gameMode.ToUpper() == "NORMAL")
            {
                service = new TicTacToeGameService();  
            }
            else
            {
                service = new FallTicTacToeGameService();
            }
            gameList.Add(service);
        }

        public ITicTacToeGameService GetGame(int gameId)
        {
            return gameList[gameId];
        }

        public IList<string> GetList()
        {
            var gameListAsString = new List<string>();
            for(var i = 0; i < this.gameList.Count; i++)
            {
                var item = this.gameList[i];
                var gameName = item.ToString();
                gameListAsString.Add(gameName);
            }
            return gameListAsString;
        }
    }
}
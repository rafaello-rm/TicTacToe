using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.service
{
    public class TicTacToeListService : ITicTacToeListService
    {
        private IList<GameListItemModel> gameList = new List<GameListItemModel>();
        public void AddGame(string gameMode, string ownerId)
        {
            GameListItemModel gameWithOwner = new GameListItemModel();
            ITicTacToeGameService service;

            if (gameMode.ToUpper() == "NORMAL")
            {
                service = new TicTacToeGameService();  
            }
            else if (gameMode.ToUpper() == "FALL")
            {
                service = new FallTicTacToeGameService();
            }
            else
            {
                service = new RandomTicTacToeGameService();
            }
            service.Reset(5, 3);

            gameWithOwner.OwnerId = ownerId;
            gameWithOwner.Game = service;
            gameList.Add(gameWithOwner);
        }
        public void RemoveGame(int gameId)
        {
            gameList.RemoveAt(gameId);
        }

        public ITicTacToeGameService GetGame(int gameId)
        {
            int gameIdToView = gameId;
            if (gameId >= gameList.Count)
            {
                gameIdToView = 0;
            }
            return gameList[gameIdToView].Game;
        }

        public IList<GameItemDto> GetList(string playerId)
        {
            var gameListAsString = new List<GameItemDto>();
            for(var i = 0; i < this.gameList.Count; i++)
            {
                string gameName;
                GameItemDto gameItemDto = new GameItemDto();
                if (playerId == gameList[i].OwnerId)
                {
                    gameItemDto.IsOwner = true;
                } else
                {
                    gameItemDto.IsOwner = false;
                }
                
                
                var item = this.gameList[i].Game;
                var model = item.GetModel();
                if(item.GetType()==typeof(TicTacToeGameService))
                {
                    gameName = "normalGame";
                }
                else if(item.GetType() == typeof(FallTicTacToeGameService))
                {
                    gameName = "fallGame";
                }
                else
                {
                    gameName = "randomGame";
                }
                gameItemDto.GameName = gameName;
                gameItemDto.GameSize = model.BoardSize;
                gameItemDto.LeftPlayer = model.Lplayer;
                gameItemDto.RightPlayer = model.Rplayer;
                gameListAsString.Add(gameItemDto);
            }
            return gameListAsString;
        }
    }

    public class GameListItemModel {
        public ITicTacToeGameService Game { get; set; }
        /// <summary>
        /// id host player (who creates game)
        /// </summary>
        public string OwnerId { get; set; }
    }
    public class GameItemDto
    {
        public string GameName { get; set; }
        public string LeftPlayer { get; set; }
        public string RightPlayer { get; set; }
        public int GameSize { get; set; }
        public bool IsOwner { get; set; }
    }
}
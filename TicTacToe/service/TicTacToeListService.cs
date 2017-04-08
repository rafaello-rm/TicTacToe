using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TicTacToe.service
{
    public class TicTacToeListService : ITicTacToeListService
    {
        private IList<GameListItemModel> gameList = new List<GameListItemModel>();
        private string serializedListGameData = string.Empty;
        private string path = @"C:\Users\Dell\Documents\Visual Studio 2015\Projects\TicTacToe\TicTacToe\Service\games.txt";

        public void AddGame(string gameMode, string ownerId)
        {
            CreateService(gameMode, ownerId);
            SaveGameData();
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
        public void SaveGameData()
        {
            List<GameData> listGameData = new List<GameData>();

            for (var i = 0; i < gameList.Count; i++)
            {
                var gameData = gameList[i].Game.GetGameData();
                gameData.OwnerId = gameList[i].OwnerId;
                listGameData.Add(gameData);
            }
            XmlSerializer serializer = new XmlSerializer(listGameData.GetType());
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, listGameData);
                serializedListGameData = sw.ToString();
            }

            File.WriteAllText(path, serializedListGameData);
        }
        public void OpenGameData()
        {

         List<GameData> deserializedListGameData;

        serializedListGameData = File.ReadAllText(path);

            XmlSerializer deserializer = new XmlSerializer(typeof(List<GameData>));
            using (TextReader tr = new StringReader(serializedListGameData))
            {
                deserializedListGameData = (List<GameData>)deserializer.Deserialize(tr);    
            }

            
            gameList.Clear();
    
            for (var i = 0; i < deserializedListGameData.Count; i++)
            {
                CreateService(deserializedListGameData[i]);
                gameList[i].Game.SetGameData(deserializedListGameData[i]);

            }

        }
        public void CreateService(string gameMode, string ownerId )
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
        public void CreateService(GameData gameData)
        {
            CreateService(gameData.GameMode, gameData.OwnerId);
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
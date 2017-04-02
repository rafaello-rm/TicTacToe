using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.service
{
    public interface ITicTacToeGameService
    {
        GameData GetGameData();
        void SetGameData(GameData gameData);
        void Reset(int boardSize, int numberForWin);
        void RenewBoard();
        string MarkCell(string playerId, int row, int col);
        string SetLeftPlayer(string playerId);
        string SetRightPlayer(string playerId);
        GameModel GetModel();
    }
    public interface ITicTacToeListService
    {
        void AddGame(string gameMode, string playerId);
        void RemoveGame(int gameId);
        IList<GameItemDto> GetList(string playerId);
        ITicTacToeGameService GetGame(int gameId);
        void OpenGameData();
    }
}

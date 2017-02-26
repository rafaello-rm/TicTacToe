using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.service
{
    public interface ITicTacToeGameService
    {
        void Reset(int boardSize, int numberForWin);
        string MarkCell(string playerId, int row, int col);
        string SetLeftPlayer(string playerId);
        string SetRightPlayer(string playerId);
        GameModel GetModel();

    }
    public interface ITicTacToeListService
    {
        void AddGame(string gameMode, string playerId);
        IList<string> GetList();
        ITicTacToeGameService GetGame(int gameId);

    }
}

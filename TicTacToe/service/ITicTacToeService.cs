using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.service
{
    public interface ITicTacToeService
    {
        void Reset(int boardSize, int numberForWin);
        string MarkCell(string playerId, int row, int col);
        string SetLeftPlayer(string playerId);
        string SetRightPlayer(string playerId);
        GameModel GetModel();

    }
}

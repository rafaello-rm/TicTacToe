using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class GameModel
    {
        public List<char> Board { get; set; }
        public string Lplayer { get; set; }
        public string Rplayer { get; set; }
        public string LastClickPlayer { get; set; }
        public string WinPlayer { get; set; }
        public int BoardSize { get; set; }
    }
}
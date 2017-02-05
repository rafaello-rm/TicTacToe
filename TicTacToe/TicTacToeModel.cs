using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class TicTacToeModel
    {
        public static List<char> Model { get; set; }
        public static string LeftPlayer { get; set; }
        public static string RightPlayer { get; set; }
        public static string LastClickPlayer { get; set; }

    }
}
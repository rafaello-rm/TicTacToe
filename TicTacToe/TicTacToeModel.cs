﻿using System;
using System.Collections.Generic;
using TicTacToe.service;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class TicTacToeModel
    {
        public static ITicTacToeGameService Service { get; set; }
    }
}
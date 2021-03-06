﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.service
{
    public class BaseService {

        private int numberForWin;
        protected GameModel gameModel;
        private string gameMode;
        public BaseService (string gameMode)
        {
            this.gameMode = gameMode;
            this.numberForWin = -1;
            this.gameModel = new GameModel();
        }
        public GameData GetGameData()
    {
        GameData gameData = new GameData(gameModel, numberForWin, gameMode);
        return gameData;
    }
    public void SetGameData(GameData gameData)
    {
        numberForWin = gameData.NumberForWin;
        gameModel = gameData.GameModel;
    }
    public void Reset(int boardSize, int numberForWin)
    {
        this.numberForWin = numberForWin;
        this.gameModel.Board = new List<char>();

        for (var i = 0; i < boardSize * boardSize; i++)
        {
            gameModel.Board.Add(' ');
        }

        this.gameModel.BoardSize = boardSize;
        this.gameModel.LastClickPlayer = string.Empty;
        this.gameModel.Lplayer = string.Empty;
        this.gameModel.Rplayer = string.Empty;
        this.gameModel.WinPlayer = string.Empty;
    }
        public void RenewBoard()
        {
            this.gameModel.Board = new List<char>();

            for (var i = 0; i < this.gameModel.BoardSize * this.gameModel.BoardSize; i++)
            {
                gameModel.Board.Add(' ');
            }
        }
        public string SetLeftPlayer(string playerId)
        {
            if (this.gameModel.Lplayer == "")
            {
                if (playerId == this.gameModel.Rplayer)
                {
                    return "YouAreOrange";
                }
                else
                {
                    this.gameModel.Lplayer = playerId;
                    return "joinGreen";
                }

            }
            else
            {
                return "colorBusy";
            }
        }
        public string SetRightPlayer(string playerId)
        {
            if (this.gameModel.Rplayer == "")
            {
                if (playerId == this.gameModel.Lplayer)
                {
                    return "YouAreGreen";
                }
                else
                {
                    this.gameModel.Rplayer = playerId;
                    return "joinOrange";
                }

            }
            else
            {
                return "colorBusy";
            }
        }
        public GameModel GetModel()
        {
            if (CheckPlayerWin('g') == true)
            {
                this.gameModel.WinPlayer = this.gameModel.Lplayer;
            }
            else if (CheckPlayerWin('o') == true)
            {
                this.gameModel.WinPlayer = this.gameModel.Rplayer;
            }
            else
            {
                this.gameModel.WinPlayer = null;
            }




            return this.gameModel;
        }
        private bool CheckPlayerWin(char colour)
        {
            bool result = false;
            int counter;
            var size = this.gameModel.BoardSize;
            for (var i = 0; i < (size * size); i += size) //check rows
            {
                counter = 0;
                for (var j = i; j < (i + size); j++)
                {
                    if (this.gameModel.Board[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == this.numberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = 0; i < size; i++) //check columns
            {
                counter = 0;
                for (var j = i; j <= (size * (size - 1)) + i; j += size)
                {
                    if (this.gameModel.Board[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == this.numberForWin)
                    {
                        result = true;
                    }
                }
            }

            for (var i = 0; i < size - 1; i++) //check diagonals \\\
            {
                counter = 0;
                for (var j = i; j < (size * size) - (size * i); j += (size + 1))
                {
                    if (this.gameModel.Board[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == this.numberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = size; i <= (size * size) - size; i += size) //check diagonals\\\
            {
                counter = 0;
                for (var j = i; j < size * size; j += (size + 1))
                {
                    if (this.gameModel.Board[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == this.numberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = 0; i < size; i++)
            {
                counter = 0;
                for (var j = i; j <= i * size; j += (size - 1))
                {
                    if (this.gameModel.Board[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == this.numberForWin)
                    {
                        result = true;
                    }
                }
            }
            for (var i = (size * 2) - 1; i < size * size; i += size)
            {
                counter = 0;
                for (var j = i; j < size * size; j += (size - 1))
                {
                    if (this.gameModel.Board[j] == colour)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter == this.numberForWin)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
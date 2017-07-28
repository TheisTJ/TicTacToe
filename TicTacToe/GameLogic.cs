using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToe
{
    class GameLogic
    {
        public Player[,] GameBoard { get; private set; }
        public List<Point> PlayHistory { get; private set; }
        public Player CurrentPlayer { get; set; }
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        public bool isFinished { get; set; }

        public GameLogic()
        {
            GameBoard = new Player[3, 3];
            PlayHistory = new List<Point>();

            PlayerOne = new Player("PlayerOne");
            PlayerTwo = new Player("PlayerTwo");
            CurrentPlayer = PlayerOne;
        }

        public void placeToken(int x, int y)
        {
            GameBoard[x, y] = CurrentPlayer;
            PlayHistory.Add(new Point(x, y));
            if (anyWinner(x, y))
            {
                return;
            }
            // Next Players Turn
            CurrentPlayer = CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
        }

        public void undoMove()
        {
            Point temp = PlayHistory[PlayHistory.Count];
            GameBoard[(int)temp.X, (int)temp.Y] = null;
            PlayHistory.Remove(temp);
            CurrentPlayer = CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
        }
    
        private bool anyWinner(int x, int y)
        {
            int coherent = 0;
            int width = GameBoard.GetLength(0);
            int height = GameBoard.GetLength(1);

            // Vertical win check
            for (int yy = 0; yy < width; yy++)
            {
                if (GameBoard[x, yy] != null && GameBoard[x, yy] == CurrentPlayer)
                {
                    coherent++;
                }
                else
                {
                    coherent = 0;
                }
                if (coherent == 3)
                {
                    isFinished = true;
                    return true;
                }
            }
            coherent = 0;
            // Horizontal win check
            for (int xx = 0; xx < height; xx++)
            {
                if(GameBoard[xx,y] != null && GameBoard[xx, y] == CurrentPlayer)
                {
                    coherent++;
                }
                else
                {
                    coherent = 0;
                }
                if (coherent == 3)
                {
                    isFinished = true;
                    return true;
                }
            }
            coherent = 0;
            // Static 3x3 diagonal down-going win check 
            for (int xx = 0; xx < height; xx++)
            {
                if (GameBoard[xx, xx] != null && GameBoard[xx, xx] == CurrentPlayer)
                {
                    coherent++;
                }
                else
                {
                    coherent = 0;
                }
                if (coherent == 3)
                {
                    isFinished = true;
                    return true;
                }
            }
            coherent = 0;
            // Static 3x3 diagonal up-going win check
            int yyy = width - 1;
            for (int xx = 0; xx < height; xx++)
            {
                if (GameBoard[xx, yyy] != null && GameBoard[xx, yyy] == CurrentPlayer)
                {
                    coherent++;
                    yyy--;
                }
                else
                {
                    coherent = 0;
                }
                if (coherent == 3)
                {
                    isFinished = true;
                    return true;
                }
            }
            coherent = 0;
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int[,] BoardState;
        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            InitializeBoardState();
        }

        public int[,] InitializeBoardState()
        {
            //list will hold alive and dead cells
            //Alive = 1, dead = 0
            BoardState = new int[Height, Width];
            Random random = new Random();
            int cellState;
            for (int cellRow = 0; cellRow < Height; cellRow++)
            {
                for (int cellColumn = 0; cellColumn < Width; cellColumn++)
                {
                    cellState = random.Next(2);
                    BoardState[cellRow, cellColumn] = cellState;
                }
            }
            return BoardState;
        }

        public void PrintBoardState()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int cellRow = 0; cellRow < Height; cellRow++)
            {
                for (int cellColumn = 0; cellColumn < Width; cellColumn++)
                {
                    if (BoardState[cellRow, cellColumn] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("# ");
                    }
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Any live cell with 0 or 1 live neighbors becomes dead
        /// Any live cell with 2 or 3 live neighbors stays alive
        /// Any live cell with more than 3 live neighbors becomes dead
        /// Any dead cell with exactly 3 live neighbors becomes alive
        /// </summary>
        /// 
        private void NextBoardState()
        {

        }
        /*
        private void CheckAllDirections()
        {
            int aliveCount = 0;
            int deadCount = 0;
            for (int row = 0; row < Height; row++)
            {
                //List<int> cellsInRow = BoardState[row];
                for (int column = 0; column < Width; column++)
                {
                    if (IsAlive(cellsInRow[column]))
                    {
                        // loop through all surrounding cells from given starting index

                        // add up the alive cells

                        // add up the dead cells

                        // Any live cell with 0 or 1 live neighbors becomes dead

                        // Any live cell with 2 or 3 live neighbors stays alive

                        // Any live cell with more than 3 live neighbors becomes dead

                    }
                    else
                    {
                        // Any dead cell with exactly 3 live neighbors becomes alive

                    }
                }
            }
        }
        */

        public bool IsAlive(int value)
        {
            return value == 1;
        }
    }
}

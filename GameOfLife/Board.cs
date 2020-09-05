using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        private int[,] BoardState;
        private Random random;

        public Board(int height, int width, int? randomSeed = null)
        {
            if (randomSeed == null)
            {
                random = new Random();
            }
            else
            {
                random = new Random((int)randomSeed);
            }
            Height = height;
            Width = width;
            InitializeBoardState();
        }

        private int[,] InitializeBoardState()
        {
            //Alive = 1, dead = 0
            BoardState = new int[Height, Width];

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
            for (int cellRow = 0; cellRow < Height; cellRow++)
            {
                for (int cellColumn = 0; cellColumn < Width; cellColumn++)
                {
                    if (BoardState[cellRow, cellColumn] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.Write("▉ ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("▉ ");
                    }
                }
            }
        }

        /// <summary>
        /// Any live cell with 0 or 1 live neighbors becomes dead
        /// Any live cell with 2 or 3 live neighbors stays alive
        /// Any live cell with more than 3 live neighbors becomes dead
        /// Any dead cell with exactly 3 live neighbors becomes alive
        /// </summary>
        public void NextState()
        {
            int[,] newBoardState = new int[Height, Width];
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    newBoardState[row, column] = GetNextCellState(row, column);
                }
            }
            BoardState = newBoardState;
        }

        private int GetNextCellState(int row, int column)
        {
            int aliveCount = 0;
            // loop through all surrounding cells from given starting index
            int rowLower = Math.Max(0, row - 1);
            int rowUpper = Math.Min(Height - 1, row + 1);
            int colLower = Math.Max(0, column - 1);
            int colUpper = Math.Min(Width - 1, column + 1);
            for (int relativeRow = rowLower; relativeRow <= rowUpper; relativeRow++)
            {
                for (int relativeColumn = colLower; relativeColumn <= colUpper; relativeColumn++)
                {
                    if (IsAlive(BoardState[relativeRow, relativeColumn]) && (relativeRow != row || relativeColumn != column))
                    {
                        aliveCount++;
                    }
                }
            }
            return GetDeathsAndBirths(row, column, aliveCount);
        }

        private int GetDeathsAndBirths(int row, int column, int aliveCount)
        {
            // if aliveCount isn't 2 or 3, cell dies
            int cell = BoardState[row, column];
            if (IsAlive(cell) && aliveCount < 2 || IsAlive(cell) && aliveCount > 3)
            {
                //return this instead
                return 0;
            }
            // if dead cell has 3 live neighbors, it becomes alive.
            else if (!IsAlive(BoardState[row, column]) && aliveCount == 3)
            {
                return 1;
            }
            // otherwise just take what was originally on the board.
            else
            {
                return BoardState[row, column];
            }
        }

        private bool IsAlive(int value)
        {
            return value == 1;
        }

        public Bitmap GetImage()
        {
            Bitmap image = new Bitmap(Height, Width);
            for (int row = 0; row < Height - 1; row++)
            {
                for (int column = 0; column < Width - 1; column++)
                {
                    image.SetPixel(row, column, BoardState[row, column] == 1 ? Color.White : Color.Black);
                }
            }
            return image;
        }
    }
}

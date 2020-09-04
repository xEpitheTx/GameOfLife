using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        private int[,] BoardState;
        private int[,] NewBoardState;
        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            InitializeBoardState();
        }

        private int[,] InitializeBoardState()
        {
            //Alive = 1, dead = 0
            BoardState = new int[Height, Width];
            Random random = new Random(1);
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
            //Console.BackgroundColor = ConsoleColor.Blue;
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
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Any live cell with 0 or 1 live neighbors becomes dead
        /// Any live cell with 2 or 3 live neighbors stays alive
        /// Any live cell with more than 3 live neighbors becomes dead
        /// Any dead cell with exactly 3 live neighbors becomes alive
        /// </summary>
        public void NextBoardState()
        {
            NewBoardState = new int[Height, Width];
            CheckAllCells();
            BoardState = NewBoardState;
        }

        private void CheckAllCells()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    ProcessRelativeCell(row, column);
                }
            }
        }

        private void ProcessRelativeCell(int row, int column)
        {
            int aliveCount = 0;
            // loop through all surrounding cells from given starting index
            int rowLower = Math.Max(0, row - 1);
            int rowUpper = Math.Min(Height - 1, row + 1);
            int colLower = Math.Max(0, column - 1);
            int colUpper = Math.Min(Width - 1, column + 1);
            for (int i = rowLower; i <= rowUpper; i++)
            {
                for (int j = colLower; j <= colUpper; j++)
                {
                    if (IsAlive(BoardState[i, j]) && (i != row || j != column))
                    {
                        aliveCount++;
                    }
                }
            }
            ProcessDeathsOrBirths(row, column, aliveCount);
        }

        private void ProcessDeathsOrBirths(int row, int column, int aliveCount)
        {
            // if aliveCount isn't 2 or 3, cell dies
            if (IsAlive(BoardState[row, column]) && aliveCount < 2 || IsAlive(BoardState[row, column]) && aliveCount > 3)
            {
                NewBoardState[row, column] = 0;
            }
            // if dead cell has 3 live neighbors, it becomes alive.
            else if (!IsAlive(BoardState[row, column]) && aliveCount == 3)
            {
                NewBoardState[row, column] = 1;
            }
            // otherwise just take what was originally on the board.
            else
            {
                NewBoardState[row, column] = BoardState[row, column];
            }
        }

        private bool IsAlive(int value)
        {
            return value == 1;
        }
    }
}

/*
        private void CheckTopRow()
        {
            for (int column = 1; column < Width - 2; column++)
            {
                int aliveCount = 0;
                for (int rowToCheck = 0; rowToCheck < 2; rowToCheck++)
                {
                    for (int columnToCheck = 0; columnToCheck < 3; columnToCheck++)
                    {
                        if (IsAlive(BoardState[rowToCheck, column + columnToCheck]) && (rowToCheck != 0 || columnToCheck != 0))
                        {
                            aliveCount++;
                        }
                    }
                }
                ProcessDeathsOrBirths(0, column, aliveCount);
            }
        }
#warning In testing, I don't think dead cells are flipping to live
        private void CheckBottomRow()
        {
            for (int column = 1; column < Width - 1; column++)
            {
                int aliveCount = 0;
                for (int rowToCheck = Height - 1; rowToCheck > Height - 2; rowToCheck--)
                {
                    for (int columnToCheck = -1; columnToCheck < 2; columnToCheck++)
                    {
                        if (IsAlive(BoardState[Height - rowToCheck, column + columnToCheck]) && (rowToCheck != Height - 1 || columnToCheck != 0))
                        {
                            aliveCount++;
                        }
                    }
                }
                ProcessDeathsOrBirths(Height - 1, column, aliveCount);
            }
        }

        private void CheckLeftColumn()
        {
            for (int row = 1; row < Height - 2; row++)
            {
                int aliveCount = 0;
                for (int rowToCheck = -1; rowToCheck < 2; rowToCheck++)
                {
                    for (int columnToCheck = 0; columnToCheck < 2; columnToCheck++)
                    {
                        if (IsAlive(BoardState[row + rowToCheck, columnToCheck]) && (rowToCheck != 0 || columnToCheck != 0))
                        {
                            aliveCount++;
                        }
                    }
                }
                ProcessDeathsOrBirths(row, 0, aliveCount);
            }
        }
#warning In testing, I don't think dead cells are flipping to live
        private void CheckRightColumn()
        {
            for (int row = 1; row < Height - 2; row++)
            {
                for (int rowToCheck = -1; rowToCheck < 2; rowToCheck++)
                {
                    int aliveCount = 0;
                    for (int columnToCheck = Width - 1; columnToCheck >= Width - 2; columnToCheck--)
                    {
                        if (IsAlive(BoardState[row + rowToCheck, columnToCheck]) && (rowToCheck != 0 || columnToCheck != Width - 1))
                        {
                            aliveCount++;
                        }
                    }
                    ProcessDeathsOrBirths(row, Width - 1, aliveCount);
                }
            }
        }
*/

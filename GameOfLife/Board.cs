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

        public int[,] InitializeBoardState()
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
            Console.WriteLine();
        }


        /// <summary>
        /// Any live cell with 0 or 1 live neighbors becomes dead
        /// Any live cell with 2 or 3 live neighbors stays alive
        /// Any live cell with more than 3 live neighbors becomes dead
        /// Any dead cell with exactly 3 live neighbors becomes alive
        /// </summary>
        /// 
        public void NextBoardState()
        {
            CheckAllDirections();
        }

        private void CheckAllDirections()
        {
            NewBoardState = new int[Height, Width];
            for (int row = 1; row < Height - 1; row++)
            {
                for (int column = 1; column < Width - 1; column++)
                {
                    int aliveCount = 0;
                    int deadCount = 0;
                    // loop through all surrounding cells from given starting index

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (IsAlive(BoardState[row + i, column + j]) && (i != 0 || j != 0))
                            {
                                aliveCount++;
                            }
                            else if (i != 0 || j != 0)
                                deadCount++;
                        }
                    }
                    if (IsAlive(BoardState[row, column]) && aliveCount <= 1 || IsAlive(BoardState[row, column]) && aliveCount >= 3)
                    {

                        // Any live cell with 0 or 1 live neighbors becomes dead
                        // Any live cell with more than 3 live neighbors becomes dead
                        NewBoardState[row, column] = 0;
                        // Any live cell with 2 or 3 live neighbors stays alive
                        //do nothing since it's already alive
                    }
                    // Any dead cell with exactly 3 live neighbors becomes alive


                    else if (!IsAlive(BoardState[row, column]) && aliveCount == 3)
                    {
                        NewBoardState[row, column] = 1;
                    }

                    else
                    {
                        NewBoardState[row, column] = BoardState[row, column];
                    }



                }
            }
            BoardState = NewBoardState;
        }

        private bool IsAlive(int value)
        {
            return value == 1;
        }
    }
}




/*
if (IsAlive(BoardState[row - 1, column - 1]))
{
    aliveCount++;
}
else
    deadCount++;
if (IsAlive(BoardState[row - 1, column]))
{
    aliveCount++;
}
else
    deadCount++;
if (IsAlive(BoardState[row - 1, column + 1]))
{
    aliveCount++;
}
else
    deadCount++;
if (IsAlive(BoardState[row, column + 1]))
{
    aliveCount++;
}
else
    deadCount++;
if (IsAlive(BoardState[row + 1, column + 1]))
{
    aliveCount++;
}
else
    deadCount++;
if (IsAlive(BoardState[row + 1, column]))
{
    aliveCount++;
}
else
    deadCount++;
if (IsAlive(BoardState[row + 1, column - 1]))
{
    aliveCount++;
}
else
    deadCount++;
if (IsAlive(BoardState[row, column - 1]))
{
    aliveCount++;
}
else
    deadCount++;
*/
// add up the alive cells

// add up the dead cells
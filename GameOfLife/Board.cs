using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<List<int>> BoardState = new List<List<int>>();
        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            InitializeBoardState();
        }

        public List<List<int>> InitializeBoardState()
        {
            //list will hold alive and dead cells
            //Alive = 1, dead = 0
            Random random = new Random();
            int cellState;
            for (int cellRow = 0; cellRow < Height; cellRow++)
            {
                List<int> cells = new List<int>();
                for (int cellColumn = 0; cellColumn < Width; cellColumn++)
                {
                    cellState = random.Next(2);
                    cells.Add(cellState);
                }
                BoardState.Add(cells);
            }
            return BoardState;
        }

        public void PrintBoardState()
        {
            foreach (List<int> sublist in BoardState)
            {
                foreach (int cell in sublist)
                {
                    Console.Write(cell);
                }
                Console.WriteLine();
            }
        }
    }
}

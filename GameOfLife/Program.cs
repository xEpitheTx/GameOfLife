using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(25, 25);
            while (true)
            {
                board.PrintBoardState();
                Thread.Sleep(1000);
                board.NextBoardState();
                Console.Clear();
            }

            
            /*
            //testing pattern
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            //Console.Clear();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            //Console.Clear();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            //Console.Clear();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            //Console.Clear();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            //Console.Clear();
            board.PrintBoardState();
            */
            
        }
    }
}

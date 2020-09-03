using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10, 10);
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            board.PrintBoardState();
            Thread.Sleep(300);
            board.NextBoardState();
            board.PrintBoardState();
        }
    }
}

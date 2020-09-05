using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using GifMotion;
using static GameOfLife.ExtensionMethods;
namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            GifCreator gifCreator = new GifCreator("GameOfLife.gif", 100, 1);
            /*
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Enter height");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter width");
            int width = int.Parse(Console.ReadLine());
            */
            Board board = new Board(100, 100, null);
            //Console.Clear();
            while (true)
            {
                //board.PrintBoardState();
                Bitmap bitmap = board.GetImage();
                //gifCreator.AddFrame(bitmap);
                gifCreator.AddFrame(ExtensionMethods.ResizeImage(bitmap, 4));
                //Thread.Sleep(750);
                board.NextState();
                //Console.Clear();
            }
        }
    }
}

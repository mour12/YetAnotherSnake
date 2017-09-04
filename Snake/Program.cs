using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        private static readonly List<Models.Snake> Objects = new List<Models.Snake>();
        
        public static void Main(string[] args)
        {
            Console.Title = Constants.Name;
            Console.WindowWidth = Constants.WindowWidth;
            Console.WindowHeight = Constants.WindowHeight;
            Console.BufferWidth = Constants.WindowWidth;
            Console.BufferHeight = Constants.WindowHeight;

            var snake = new Models.Snake();
            Objects.Add(snake);

            while (true)
            {
                Update();
                Redraw();
                Thread.Sleep(200);
            }
        }

        private static void Update()
        {
            foreach (var item in Objects)
            {
                item.Move();
            }
        }

        private static void Redraw()
        {
            Console.Clear();
            foreach (var item in Objects)
            {
                item.Draw();
            }
        }
    }
}
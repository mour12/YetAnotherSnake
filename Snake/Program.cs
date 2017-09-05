using System;
using System.Collections.Generic;
using System.Threading;
using Snake.Models;
using Snake.Utilities;

namespace Snake
{
    internal class Program
    {
        private static readonly List<IMovable> Objects = new List<IMovable>();
        
        public static void Main(string[] args)
        {
            Console.Title = Constants.Name;
            Console.CursorVisible = false;
            Console.SetWindowSize(Constants.WindowWidth, Constants.WindowHeight);
            Console.BufferWidth = Constants.WindowWidth;
            Console.BufferHeight = Constants.WindowHeight;

            var snake = new Models.Snake(Constants.WindowWidth / 2, Constants.WindowHeight / 2);
            Objects.Add(snake);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }
                }
                
                Update();
                Thread.Sleep(100);
            }
        }

        private static void Update()
        {
            foreach (var item in Objects)
            {
                item.Move();
            }
        }
    }
}
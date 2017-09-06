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
            Console.SetWindowSize(Constants.PlaygroundWidth + 2 * Constants.Margin, Constants.PlaygroundHeight + 2 * Constants.Margin);
            Console.BufferWidth = Constants.PlaygroundWidth + 2 * Constants.Margin;
            Console.BufferHeight = Constants.PlaygroundHeight + 2 * Constants.Margin;
            
            InitializeWorld();

            var snake = new Models.Snake(Constants.PlaygroundWidth / 2, Constants.PlaygroundHeight / 2);
            snake.Initialize();
            Objects.Add(snake);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input;
                    do
                    {
                        Console.SetCursorPosition(Console.BufferWidth - 2, Console.BufferHeight - 1);
                        input = Console.ReadKey(false);
                    } while (Console.KeyAvailable);
                    
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
                Thread.Sleep(1000);
            }
        }

        private static void InitializeWorld()
        {
            Console.SetCursorPosition(Constants.Margin - 1, Constants.Margin - 1);
            Console.Write(new String('#', Constants.PlaygroundWidth + 2));
            for (var i = 0; i < Constants.PlaygroundHeight; i++)
            {
                Console.SetCursorPosition(Constants.Margin - 1, Constants.Margin  + i);
                Console.Write('#');
                Console.SetCursorPosition(Constants.PlaygroundWidth + Constants.Margin, Constants.Margin  + i);
                Console.Write('#');
            }
            Console.SetCursorPosition(Constants.Margin - 1, Constants.PlaygroundHeight + Constants.Margin);
            Console.Write(new String('#', Constants.PlaygroundWidth + 2));
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
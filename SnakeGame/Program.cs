using System;
using System.Threading;
using SnakeGame.Models;

namespace SnakeGame
{
    internal class Program
    {
        private static Random _rand = new Random();
        private static Snake _snake = new Snake(Constants.PlaygroundWidth / 2, Constants.PlaygroundHeight / 2);
        private static Food? _food = null;
        
        public static void Main(string[] args)
        {
            Console.Title = Constants.Name;
            Console.CursorVisible = false;
            Console.SetWindowSize(Constants.PlaygroundWidth + 2 * Constants.Margin, Constants.PlaygroundHeight + 2 * Constants.Margin);
            Console.BufferWidth = Constants.PlaygroundWidth + 2 * Constants.Margin;
            Console.BufferHeight = Constants.PlaygroundHeight + 2 * Constants.Margin;
            
            InitializeWorld();
            
            _snake.Initialize();

            while (true)
            {
                if (!_food.HasValue)
                {
                    _food = GenerateFood();
                    _food.Value.Position.Draw();
                }
                
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
                            _snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            _snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            _snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            _snake.Direction = Direction.Down;
                            break;
                    }
                }

                if (_snake.CanEat(_food.Value))
                {
                    _snake.AddValue(_food.Value.Value);
                    _food = null;
                }
                
                _snake.Move();
                Thread.Sleep(50);
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

        private static Food GenerateFood()
        {
            Point position;
            do
            {
                int x = _rand.Next(Constants.PlaygroundWidth);
                int y = _rand.Next(Constants.PlaygroundHeight);
                position = new Point(x, y, '@');
            } while (_snake.IsIntersecting(position));
            
            return new Food(position, Constants.FoodValue);
        }
    }
}
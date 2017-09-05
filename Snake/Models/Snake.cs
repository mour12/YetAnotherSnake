using System;
using Snake.Utilities;

namespace Snake.Models
{
    internal sealed class Snake : IMovable
    {
        private Direction _direction = Direction.Right;
        private readonly Deque<Point> _points = new Deque<Point>();

        public Direction Direction
        {
            get => _direction;
            set
            {
                switch (_direction)
                {
                    case Direction.Up:
                        if (value != Direction.Down)
                        {
                            _direction = value;
                        }
                        break;
                    case Direction.Down:
                        if (value != Direction.Up)
                        {
                            _direction = value;
                        }
                        break;
                    case Direction.Left:
                        if (value != Direction.Right)
                        {
                            _direction = value;
                        }
                        break;
                    case Direction.Right:
                        if (value != Direction.Left)
                        {
                            _direction = value;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Snake(int x, int y, int lenght = 5)
        {
            if (lenght < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(lenght), lenght, "Length cannot be less than 1.");
            }
            
            for (var i = x - lenght / 2; i < x + lenght / 2; i++)
            {
                _points.PushFront(new Point{ X = i, Y = y });
            }
        }

        public void Initialize()
        {
            foreach (var point in _points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write('S');
            }
        }
        
        public void Move()
        {
            var prevTail = _points.PopBack();
            Console.SetCursorPosition(prevTail.X, prevTail.Y);
            Console.Write(' ');

            var newHead = _points.PeekFront();

            switch (Direction)
            {
                case Direction.Up:
                    newHead.Y--;
                    break;
                case Direction.Down:
                    newHead.Y++;
                    break;
                case Direction.Left:
                    newHead.X--;
                    break;
                case Direction.Right:
                    newHead.X++;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write('S');
            
            _points.PushFront(newHead);
        }
    }
}
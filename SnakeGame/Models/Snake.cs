using System;
using System.Linq;
using SnakeGame.Utilities;

namespace SnakeGame.Models
{
    internal sealed class Snake
    {
        private int _value;
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
            
            for (var i = x - (lenght + 1) / 2; i < x + lenght / 2; i++)
            {
                _points.PushFront(new Point(i, y, 'S'));
            }
        }

        public void Initialize()
        {
            foreach (var point in _points)
            {
                point.Draw();
            }
        }
        
        public void Move()
        {
            if (_value > 0)
            {
                --_value;
            }
            else
            {
                var prevTail = _points.PopBack();
                prevTail.Erase();
            }

            var oldHead = _points.PeekFront();
            Point newHead;

            switch (Direction)
            {
                case Direction.Up:
                    newHead = new Point(oldHead.X, (oldHead.Y + Constants.PlaygroundHeight - 1) % Constants.PlaygroundHeight, 'S');
                    break;
                case Direction.Down:
                    newHead = new Point(oldHead.X, (oldHead.Y + 1) % Constants.PlaygroundHeight, 'S');
                    break;
                case Direction.Left:
                    newHead = new Point((oldHead.X + Constants.PlaygroundWidth - 1) % Constants.PlaygroundWidth, oldHead.Y, 'S');
                    break;
                case Direction.Right:
                    newHead = new Point((oldHead.X + 1) % Constants.PlaygroundWidth, oldHead.Y, 'S');
                    break;
                default:
                    throw new InvalidOperationException();
            }
            
            newHead.Draw();
            
            _points.PushFront(newHead);
        }

        public bool IsIntersecting(Point other)
        {
            return _points.Any(point => point == other);
        }

        public bool CanEat(Food food)
        {
            var head = _points.PeekFront();

            return head == food.Position;
        }

        public void AddValue(int value)
        {
            _value += value;
        }
    }
}
using System;
using Snake.Utilities;

namespace Snake.Models
{
    internal sealed class Snake : IMovable, IDrawable
    {
        private readonly Deque<Point> _points = new Deque<Point>();
        public Direction Direction { get; set; } = Direction.Right;

        public Snake()
        {
            const int x = Constants.WindowWidth / 2 - 2;
            const int y = Constants.WindowHeight / 2;

            for (var i = x; i < x + 5; i++)
            {
                _points.PushFront(new Point{ X = i, Y = y });
            }
        }
        
        public void Move()
        {
            _points.PopBack();

            var head = _points.PeekFront();

            switch (Direction)
            {
                case Direction.Up:
                    head.Y++;
                    break;
                case Direction.Down:
                    head.Y--;
                    break;
                case Direction.Left:
                    head.X--;
                    break;
                case Direction.Right:
                    head.X++;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            
            _points.PushFront(head);
        }

        public void Draw()
        {
            foreach (var point in _points)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write('S');
            }
        }
    }
}
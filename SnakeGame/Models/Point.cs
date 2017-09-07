using System;
using System.Runtime.InteropServices;

namespace SnakeGame.Models
{
    [StructLayout(LayoutKind.Auto)]
    internal struct Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }
        public char Symbol { get; }

        public Point(int x, int y, char symbol)
        {
            if (x < 0 || x >= Constants.PlaygroundWidth)
            {
                throw new ArgumentOutOfRangeException(nameof(x), x, $"X must be within 0 and {Constants.PlaygroundWidth - 1}");
            }
            if (y < 0 || y >= Constants.PlaygroundHeight)
            {
                throw new ArgumentOutOfRangeException(nameof(y), y, $"Y must be within 0 and {Constants.PlaygroundHeight - 1}");
            }

            X = x;
            Y = y;
            Symbol = symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Constants.Margin + X, Constants.Margin + Y);
            Console.Write(Symbol);
        }

        public void Erase()
        {
            Console.SetCursorPosition(Constants.Margin + X, Constants.Margin + Y);
            Console.Write(' ');
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point && Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
    }
}
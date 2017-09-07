using System.Runtime.InteropServices;

namespace SnakeGame.Models
{
    [StructLayout(LayoutKind.Auto)]
    internal struct Food
    {
        public Point Position { get; }
        public int Value { get; }

        public Food(Point position, int value)
        {
            Position = position;
            Value = value;
        }
    }
}
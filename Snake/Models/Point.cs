﻿using System.Runtime.InteropServices;

namespace Snake.Models
{
    [StructLayout(LayoutKind.Auto)]
    internal struct Point
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set => _x = (Constants.WindowWidth + value) % Constants.WindowWidth;
        }

        public int Y
        {
            get => _y;
            set => _y = (Constants.WindowHeight + value) % Constants.WindowHeight;
        }
    }
}
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
            set => _x = value % Constants.WindowWidth;
        }

        public int Y
        {
            get => _y;
            set => _y = value % Constants.WindowHeight;
        }
    }
}
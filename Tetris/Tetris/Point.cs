﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            C = p.C;
        }
        public Point(int coordX,int coordY,char symbol)
        {
            X = coordX;
            Y = coordY;
            C = symbol;
        }

        public void Draw()
        {
            DrawerProvier.Drawer.DrawPoint(X, Y);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    Y += 1;
                    break;
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.RIGHT:
                    X += 1;
                    break;
                case Direction.UP:
                    Y -= 1;
                    break;
            }
        }

        public void Hide()
        {
            DrawerProvier.Drawer.HidePoint(X, Y);
        }
    }
}

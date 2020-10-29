using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Point
    {
        public int x;
        public int y;
        public char c;

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            c = p.c;
        }
        public Point(int coordX,int coordY,char symbol)
        {
            x = coordX;
            y = coordY;
            c = symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.CursorVisible = false;
        }

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    y += 1;
                    break;
                case Direction.LEFT:
                    x -= 1;
                    break;
                case Direction.RIGHT:
                    x += 1;
                    break;
            }
        }

        public void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        public const int WIDTH = 40;
        public const int HEIGHT = 30;

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[HEIGHT][];
            for(int i = 0; i < HEIGHT; i++)
            {
                _heap[i] = new bool[WIDTH];
            }
        }

        public static void AddFigure(Figure fig)
        {
            foreach(var p in fig.points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }
    }
}

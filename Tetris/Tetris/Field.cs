using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        public const int WIDTH = 20;
        public const int HEIGHT = 20;

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[HEIGHT][];
            for (int i = 0; i < HEIGHT; i++)
            {
                _heap[i] = new bool[WIDTH];
            }
        }

        public static void AddFigure(Figure fig)
        {
            foreach (var p in fig.points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        internal static void TryDeleteLines()
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                int counter = 0;
                for (int i = 0; i < WIDTH; i++)
                {
                    if (_heap[j][i])
                        counter++;
                    if (counter == WIDTH)
                    {
                        DeleteLine(j);
                        Redraw();
                    }

                }
            }
        }

        private static void Redraw()
        {
            for (int j = 0; j < HEIGHT-1; j++)
            {
                for (int i = 0; i < WIDTH; i++)
                {
                    if (_heap[j][i])
                        Drawer.DrawPoint(i, j);
                    else
                        Drawer.HidePoint(i, j);
                }
            }
        }

        private static void DeleteLine(int line)
        {
            for (int j = line; j >= 0; j--)
            {
                for (int i = 0; i < WIDTH; i++)
                {
                    if (j == 0)
                        _heap[j][i] = false;
                    else
                        _heap[j][i] = _heap[j - 1][i];
                }
            }
        }

        internal static void GameOver()
        {
            
        }
    }
}

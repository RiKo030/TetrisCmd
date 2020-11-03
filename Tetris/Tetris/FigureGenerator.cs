using System;

namespace Tetris
{
    internal class FigureGenerator
    {
        private int _x;
        private int _y;
        private char _c;

        private Random _rand = new Random();

        public FigureGenerator(int coordX, int coordY)
        {
            _x = coordX;
            _y = coordY;
        }

        public Figure GetNewFigure()
        {
            if(_rand.Next(0, 2) == 0)
            {
                return new Square(_x, _y, _c);
            }
            else
            {
                return new HorisontalStick(_x, _y, _c);
            }
        }
    }
}
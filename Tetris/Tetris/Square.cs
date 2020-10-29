using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Square:Figure
    {
        public Square(int coordX, int coordY, char symbol)
        {
            points[0] = new Point(coordX, coordY, symbol);
            points[1] = new Point(coordX+1, coordY, symbol);
            points[2] = new Point(coordX, coordY+1, symbol);
            points[3] = new Point(coordX+1, coordY+1, symbol);
            Draw();
        }

        public override void Rotate()
        {
            
        }
    }
}

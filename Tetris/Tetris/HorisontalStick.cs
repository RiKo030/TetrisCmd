using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class HorisontalStick:Figure
    {
        public HorisontalStick(int coordX,int coordY, char symbol)
        {
            points[0] = new Point(coordX, coordY, symbol);
            points[1] = new Point(coordX, coordY+1, symbol);
            points[2] = new Point(coordX, coordY+2, symbol);
            points[3] = new Point(coordX, coordY+3, symbol);
            Draw();
        }

        public override void Rotate()
        {
            if (points[0].x == points[1].x)
            {
                RotateHorisontal();
            }
            else
            {
                RotateVertical();
            }
        }

        private void RotateHorisontal()
        {
            for(int i = 0; i < points.Length; i++)
            {
                points[i].y = points[0].y;
                points[i].x = points[0].x + i;
            }
        }

        private void RotateVertical()
        {
            for(int i=0;i<points.Length; i++)
            {
                points[i].y = points[0].y + i;
                points[i].x = points[0].x;
            }
        }
    }
}

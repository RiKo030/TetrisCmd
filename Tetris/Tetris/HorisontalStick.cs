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
            if (points[0].X == points[1].X)
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
            if (Field.WIDTH - points[0].X >= 4)
            {
                Hide();
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].Y = points[0].Y;
                    points[i].X = points[0].X + i;
                }
                
                Draw();
            }
            else
            {
                Hide();
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].Y = points[0].Y;
                    points[i].X = points[0].X - i;
                }
                
                Draw();
            }

        }

        private void RotateVertical()
        {
            for(int i=0;i<points.Length; i++)
            {
                Hide();
                points[i].Y = points[0].Y + i;
                points[i].X = points[0].X;
                Draw();
            }
        }
    }
}

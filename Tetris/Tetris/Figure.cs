using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Figure
    {
        const int LENGTH = 4;
        public Point[] points = new Point[LENGTH];

        public void Draw()
        {
            foreach(Point p in points)
            {
                p.Draw();
            }
        }

        //public void Move(Direction dir)
        //{
        //    Hide();
        //    foreach(Point p in points)
        //    {
        //        p.Move(dir);
        //    }
        //    Draw();
        //}

        internal FigureStatus TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            var result = VerifyPosition(clone);
            if (result == FigureStatus.SUCCESS)
                points = clone;
            Draw();

            return result;
        }

        private FigureStatus VerifyPosition(Point[] clone)
        {
            foreach(Point p in clone)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.WIDTH-1)
                    return FigureStatus.BORDER_STRIKE;
                if (p.Y >= Field.HEIGHT - 2)
                    return FigureStatus.DOWN_BORDER_STRIKE;
                if (Field.CheckStrike(p))
                    return FigureStatus.HEAP_STRIKE;
            }

            return FigureStatus.SUCCESS;
        }

        public void Move(Point[] pList,Direction dir)
        {
            foreach(Point p in pList)
            {
                p.Move(dir);
            }
        }


        private Point[] Clone()
        {
            var newPoints = new Point[LENGTH];
            for(int i = 0; i < LENGTH; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        public void Hide()
        {
            foreach(Point p in points)
            {
                p.Hide();
            }
        }

        public abstract void Rotate();

    }
}

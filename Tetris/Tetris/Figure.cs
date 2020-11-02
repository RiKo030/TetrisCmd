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
            Move(dir);
            var result = VerifyPosition();
            if (result != FigureStatus.SUCCESS)
                Move(Reverse(dir));


            Draw();
            return result;
        }

        private Direction Reverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                case Direction.UP:
                    return Direction.DOWN;

            }
            return dir;
        }

        private FigureStatus VerifyPosition()
        {
            foreach(Point p in points)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.WIDTH)
                    return FigureStatus.BORDER_STRIKE;
                if (p.Y >= Field.HEIGHT-1)
                    return FigureStatus.DOWN_BORDER_STRIKE;
                if (Field.CheckStrike(p))
                    return FigureStatus.HEAP_STRIKE;
            }
            return FigureStatus.SUCCESS;

            
        }

        public void Move(Direction dir)
        {
            foreach(Point p in points)
            {
                p.Move(dir);
            }
        }

        public void Hide()
        {
            foreach(Point p in points)
            {
                p.Hide();
            }
        }

        internal bool IsOnTop()
        {
            if (points[0].Y == 0)
                return true;
            else return false;
        }

        public abstract void Rotate();

    }
}

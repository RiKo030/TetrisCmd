using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static FigureGenerator generator = new FigureGenerator(20, 0, '*');
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.WIDTH, Field.HEIGHT);
            Console.SetBufferSize(Field.WIDTH, Field.HEIGHT);
            
            Figure figure = generator.GetNewFigure();
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(figure, key);
                    ProcessResult(result, ref figure);
                }
            }
        }

        private static bool ProcessResult(FigureStatus result, ref Figure figure)
        {
            if (result == FigureStatus.HEAP_STRIKE || result == FigureStatus.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(figure);
                figure = generator.GetNewFigure();
                return true;
            }
            else return false;
        }

        private static FigureStatus HandleKey(Figure figure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return figure.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return figure.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return figure.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                    figure.Rotate();
                    break;
                default: break;
            }

            return FigureStatus.SUCCESS;
        }
    }

       
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.WIDTH, Field.HEIGHT);
            Console.SetBufferSize(Field.WIDTH, Field.HEIGHT);
            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure figure = generator.GetNewFigure();
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandleKey(figure, key);
                }
            }
        }

        private static void HandleKey(Figure figure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    figure.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    figure.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    figure.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    figure.Rotate();
                    break;
                default: break;
            }
        }
    }

       
}

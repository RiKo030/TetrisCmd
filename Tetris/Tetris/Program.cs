using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris
{
    class Program
    {
        static FigureGenerator generator = new FigureGenerator(Field.WIDTH/2, Field.HEIGHT*0);
        static Figure figure = generator.GetNewFigure();
        static System.Timers.Timer timer;
        const int TIMER_INTERVAL = 100;
        static private Object _lockObject = new object();
        static void Main(string[] args)
        {
            DrawerProvier.Drawer.InitField();
            SetTimer();
            
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(figure, key);
                    ProcessResult(result, ref figure);
                    Monitor.Exit(_lockObject);
                }
            }
        }

        public static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = figure.TryMove(Direction.DOWN);
            ProcessResult(result, ref figure);
            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(FigureStatus result, ref Figure figure)
        {
            if (result == FigureStatus.HEAP_STRIKE || result == FigureStatus.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(figure);
                Field.TryDeleteLines();
                if(figure.IsOnTop())
                {
                    DrawerProvier.Drawer.WriteGameOver();
                    timer.Stop();
                    return true;
                }
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
                case ConsoleKey.Spacebar:
                    figure.Rotate();
                    break;
                default: break;
            }

            return FigureStatus.SUCCESS;
        }
    }

       
}

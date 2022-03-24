using System;
using System.Threading;

namespace WanderingStar
{
    public class Program
    {
        static void Main(string[] args)
        {
            StarParameters starParameters = new StarParameters();
            Console.WriteLine("You can control the star usind WASD buttons");
            CommandsParser parser = new CommandsParser();
            while (!parser.TryReadStartCommandFromConsole(out starParameters))
            {
                Console.WriteLine("Invalid command syntax");
            }
            Console.CursorVisible = false;
            Console.Clear();
            StartDrawing(starParameters);
        }

        private static void WriteByCoordinates(int x, int y, string output)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(output);
        }

        private static void StartDrawing(StarParameters starParameters)
        {
            DirectionReader reader = new DirectionReader();
            int x = 0, y = 0;
            reader.Run();
            while (true)
            {
                if (starParameters.DeletePrevious)
                {
                    WriteByCoordinates(x, y, " ");
                }

                switch (reader.Direction)
                {
                    case Direction.Left: x--; break;
                    case Direction.Right: x++; break;
                    case Direction.Up: y--; break;
                    case Direction.Down: y++; break;
                }

                if (x < 0)
                {
                    x = 0;
                }

                if (x >= Console.WindowWidth)
                {
                    x = Console.WindowWidth - 1;
                }

                if (y < 0)
                {
                    y = 0;
                }

                WriteByCoordinates(x, y, "*");
                Thread.Sleep(starParameters.WaitTime);
            }
        }
    }
}

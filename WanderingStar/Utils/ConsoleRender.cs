using System;
using WanderingStar.Core;
using WanderingStar.Interfaces;

namespace WanderingStar.Utils
{
    public class ConsoleRender : IRender
    {
        public int MaxWidth => Console.WindowWidth;

        public void WriteByCoordinates(Coordinate coordinate, char output)
        {
            Console.SetCursorPosition(coordinate.X, coordinate.Y);
            Console.Write(output);
        }

        public void ClearPosition(Coordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.X, coordinate.Y);
            Console.Write(' ');
        }
    }
}

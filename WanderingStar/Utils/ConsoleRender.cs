using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderingStar.Core;
using WanderingStar.Interfaces;

namespace WanderingStar
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

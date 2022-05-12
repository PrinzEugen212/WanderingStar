using System;
using WanderingStar.Core;

namespace WanderingStar.Client.Utils
{
    public class ConsoleRender
    {
        private Symbol symbol;

        public ConsoleRender(Symbol symbol)
        {
            this.symbol = symbol;
        }

        public void Render(Coordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.X, coordinate.Y);
            Console.Write(symbol.symbol);
        }
    }
}

using System;
using WanderingStar.Core;
using WanderingStar.Utils;

namespace WanderingStar
{
    public class Program
    {

        static void Main(string[] args)
        {
            GameParameters gameParameters;

            Console.WriteLine("You can control the star using WASD buttons");
            CommandsParser parser = new CommandsParser();

            while (!parser.TryReadStartCommandFromConsole(out gameParameters))
            {
                Console.WriteLine("Invalid command syntax");
            }

            Console.CursorVisible = false;
            Console.Clear();

            Symbol symbol = new Symbol(new Coordinate(0, 0));
            ConsoleRender consoleRender = new ConsoleRender();
            DirectionReader directionReader = new DirectionReader(new KeyParser());
            Game game = new Game(gameParameters, symbol, directionReader, consoleRender);

            directionReader.CommandAppeared += (sender, type) =>
            {
                if (type == Enums.CommandType.End)
                {
                    game.IsRunning = false;
                    directionReader.Dispose();
                }
            };

            directionReader.Run();
            game.StartDrawing();
        }
    }
}

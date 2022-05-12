using System;
using System.Threading.Tasks;
using WanderingStar.Client;
using WanderingStar.Client.Utils;
using WanderingStar.Core;
using WanderingStar.Server;

namespace WanderingStar.Start
{
    internal class Program
    {
        const string ipAddress = "127.0.0.1";
        const int port = 8000;

        static void Main(string[] args)
        {
            Parameters parameters;
            CommandsParser parser = new CommandsParser();

            if (args.Length > 0)
            {
                parser.TryParseArguments(args, out parameters);
            }
            else
            {
                Console.WriteLine("You can control the star using WASD buttons");
                while (!parser.TryReadStartCommandFromConsole(out parameters))
                {
                    Console.WriteLine("Invalid command syntax");
                }
            }

            Console.CursorVisible = false;
            Console.Clear();
            Symbol symbol = new Symbol(new Coordinate(0, 0));
            Task.Run(() =>
            {
                Game game = new Game(symbol.Coordinate, parameters.WaitTime, ipAddress, port);
                game.Start();
            });
            ConsoleRender consoleRender = new ConsoleRender(symbol);
            Reader directionReader = new Reader(new KeyParser(), consoleRender, ipAddress, port, parameters.WaitTime);
            directionReader.Run();
        }
    }
}

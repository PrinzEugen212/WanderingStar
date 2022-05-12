using System;
using System.Collections.Generic;
using System.Linq;
using WanderingStar.Core;
using WanderingStar.Core.Enums;

namespace WanderingStar.Client.Utils
{
    public class CommandsParser
    {
        private static Dictionary<CommandType, string> commandsKeys = new Dictionary<CommandType, string>()
        {
            { CommandType.Start, "-start" },
            { CommandType.End, "-end" },
        };

        public bool TryReadStartCommandFromConsole(out Parameters parameters)
        {
            Console.WriteLine("Please enter the start command: " +
                "\n-start\n" +
                "\tt <wait time in ms> - delay before next star will be drew\n" +
                "\td - optinal parameter. If present - previous symbol will be deleted");
            string commandLine = Console.ReadLine();
            try
            {
                parameters = ParseStart(commandLine);
            }
            catch
            {
                parameters = null;
                return false;
            }

            return true;
        }

        public bool TryParseArguments(string[] args, out Parameters parameters)
        {
            try
            {
                parameters = ParseStart(args);
            }
            catch
            {
                parameters = null;
                return false;
            }

            return true;
        }

        public Parameters ParseStart(string commandLine)
        {
            return ParseStart(commandLine.Split());
        }

        public Parameters ParseStart(string[] arguments)
        {
            Parameters parameters = new Parameters();
            if (arguments[0] != commandsKeys[CommandType.Start] || arguments.Length > 4)
            {
                throw new ArgumentException("Invalid command");
            }

            if (arguments[1] != "t")
            {
                throw new ArgumentException("Invalid command");
            }

            if (int.TryParse(arguments[2], out int time))
            {
                parameters.WaitTime = time;
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            if (arguments.Length > 3)
            {
                if (arguments[3] != "d")
                {
                    throw new ArgumentException("Invalid command");
                }

                parameters.DeletePrevious = true;
            }
            else
            {
                parameters.DeletePrevious = arguments.Length != 3;
            }

            return parameters;
        }
    }
}

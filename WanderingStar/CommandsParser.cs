using System;
using System.Collections.Generic;

namespace WanderingStar
{
    public class CommandsParser
    {
        private static Dictionary<CommandType, string> commandsKeys = new Dictionary<CommandType, string>()
        {
            { CommandType.Start, "-start" },
            { CommandType.End, "-end" },
        };

        public bool TryReadStartCommandFromConsole(out StarParameters starParameters)
        {
            Console.WriteLine("Please enter the start command: " +
                "\n-start\n" +
                "\tt <wait time in ms> - delay before next star will be drew\n" +
                "\td - optinal parameter. If present - previous symbol will be deleted");
            string commandLine = Console.ReadLine();
            try
            {
                starParameters = ParseStart(commandLine);
            }
            catch
            {
                starParameters = null;
                return false;
            }
            return true;
        }

        public StarParameters ParseStart(string commandLine)
        {
            StarParameters starParameters = new StarParameters();
            string[] parameters = commandLine.Split();
            if (parameters[0] != commandsKeys[CommandType.Start] || parameters.Length > 4)
            {
                throw new ArgumentException("Invalid command");
            }

            if (parameters[1] != "t")
            {
                throw new ArgumentException("Invalid command");
            }

            if (int.TryParse(parameters[2], out int time))
            {
                starParameters.WaitTime = time;
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            if (parameters.Length > 3)
            {
                if (parameters[3] != "d")
                {
                    throw new ArgumentException("Invalid command");
                }

                starParameters.DeletePrevious = true;
            }
            else
            {
                starParameters.DeletePrevious = parameters.Length != 3;
            }

            return starParameters;
        }
    }
}

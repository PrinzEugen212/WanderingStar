using System;
using WanderingStar.Enums;
using WanderingStar.Interfaces;

namespace WanderingStar
{
    public class KeyParser : IKeyParser
    {
        public (CommandType type, Direction direction) Parse(ConsoleKey key)
        {
            return GetCommand(key);
        }

        private (CommandType type, Direction direction) GetCommand(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A: return (CommandType.Move, Direction.Left);
                case ConsoleKey.S: return (CommandType.Move, Direction.Down);
                case ConsoleKey.W: return (CommandType.Move, Direction.Up);
                case ConsoleKey.D: return (CommandType.Move, Direction.Right);
                case ConsoleKey.R: return (CommandType.End, Direction.None);
            }

            return (CommandType.Move, Direction.None);
        }
    }
}

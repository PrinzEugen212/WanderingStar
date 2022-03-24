using System;
using WanderingStar.Enums;

namespace WanderingStar.Interfaces
{
    public interface IKeyParser
    {
        (CommandType type, Direction direction) Parse(ConsoleKey key);
    }
}
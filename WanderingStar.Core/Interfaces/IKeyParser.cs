using System;
using WanderingStar.Core.Enums;

namespace WanderingStar.Interfaces
{
    public interface IKeyParser
    {
        (CommandType type, Direction direction) Parse(ConsoleKey key);
    }
}
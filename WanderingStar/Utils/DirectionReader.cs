using System;
using System.Threading.Tasks;
using WanderingStar.Enums;
using WanderingStar.Interfaces;

namespace WanderingStar
{
    public class DirectionReader : IDirection, IDisposable
    {
        private Direction direction;
        private IKeyParser keyParser;

        public bool IsRunning { get; private set; } = false;

        public event EventHandler<CommandType> CommandAppeared;

        public DirectionReader(IKeyParser keyParser)
        {
            direction = Direction.Right;
            this.keyParser = keyParser;
        }

        public Direction Direction
        {
            get { return direction; }
            private set { direction = value; }
        }

        public void Run()
        {
            IsRunning = true;
            Task.Run(() =>
            {
                while (IsRunning)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    (CommandType type, Direction direction) parseResult = keyParser.Parse(key);
                    direction = parseResult.direction;
                    CommandAppeared?.Invoke(this, parseResult.type);
                }
            });
        }

        public void Dispose()
        {
            IsRunning = false;
        }
    }
}

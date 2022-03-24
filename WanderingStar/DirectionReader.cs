using System;
using System.Threading.Tasks;

namespace WanderingStar
{
    public class DirectionReader
    {
        private Direction direction;

        public DirectionReader()
        {
            direction = Direction.Right;
        }

        public Direction Direction
        {
            get { return direction; }
            private set { direction = value; }
        }

        private Direction GetDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A: return Direction.Left;
                case ConsoleKey.S: return Direction.Down;
                case ConsoleKey.W: return Direction.Up;
                case ConsoleKey.D: return Direction.Right;
            }

            return Direction.Right;
        }

        public void Run()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    direction = GetDirection(key);
                }
            });
        }
    }
}

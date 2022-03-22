using System;
using System.Threading.Tasks;

namespace WanderingStar
{
    public class Reader
    {
        private Direction direction;

        public Reader()
        {
            direction = Direction.Right;
        }

        public Direction Direction
        {
            get { return direction; }
            private set { direction = value; }
        }

        public Direction GetDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A: return Direction.Left;
                case ConsoleKey.S: return Direction.Down;
                case ConsoleKey.W: return Direction.Up;
                case ConsoleKey.D: return Direction.Right;
                default: return Direction.Right;
            }
        }

        public void Read()
        {
            Task.Run(() =>
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                direction = GetDirection(key);
            });
            //return Direction.None;
        }
    }
}

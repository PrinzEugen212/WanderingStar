using WanderingStar.Core.Interfaces;

namespace WanderingStar.Core
{
    public class Coordinate : ICoordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}

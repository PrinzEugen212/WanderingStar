namespace WanderingStar.Core
{
    public class Symbol
    {
        public Symbol(Coordinate coordinate)
        {
            this.Coordinate = coordinate;
        }

        public Symbol(char symbol, Coordinate coordinate)
        {
            this.symbol = symbol;
            this.Coordinate = coordinate;
        }

        public readonly char symbol = '*';
        public Coordinate Coordinate { get; set; }

    }
}

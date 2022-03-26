using System;
using System.Threading;
using System.Threading.Tasks;
using WanderingStar.Enums;
using WanderingStar.Interfaces;

namespace WanderingStar.Core
{
    public class Game : IRenderable
    {
        private Parameters parameters;
        private Symbol symbol;
        private IDirection reader;
        private Direction previousDirection;

        public event EventHandler NeedToClearPosition;

        public bool IsRunning { get; set; } = false;

        public bool RenderCondition => IsRunning;

        public object ObjectToRender => symbol.symbol;

        public Coordinate RenderCoordinate => symbol.Coordinate;

        public Game(Parameters parameters, Symbol symbol, IDirection reader)
        {
            this.parameters = parameters;
            this.symbol = symbol;
            this.reader = reader;
        }

        public void Start()
        {
            IsRunning = true;
        }



        private Coordinate MoveSymbol(Coordinate coordinate)
        {
            Coordinate newCoordinate = new Coordinate(coordinate.X, coordinate.Y);
            switch (reader.Direction)
            {
                case Direction.Left: newCoordinate.X--; break;
                case Direction.Right: newCoordinate.X++; break;
                case Direction.Up: newCoordinate.Y--; break;
                case Direction.Down: newCoordinate.Y++; break;
                case Direction.None: ContinueSymbolMoving(newCoordinate); break;
            }
            return newCoordinate;
        }

        private void ContinueSymbolMoving(Coordinate coordinate)
        {
            switch (previousDirection)
            {
                case Direction.Left: coordinate.X--; break;
                case Direction.Right: coordinate.X++; break;
                case Direction.Up: coordinate.Y--; break;
                case Direction.Down: coordinate.Y++; break;
                case Direction.None: throw new Exception("Direction was None");
            }
        }

        public void ProcessNextIteration()
        {
            if (IsRunning)
            {
                if (parameters.DeletePrevious)
                {
                    NeedToClearPosition?.Invoke(this, null);
                }

                Coordinate newCoordinate = MoveSymbol(symbol.Coordinate);
                symbol.Coordinate = newCoordinate;
                if (reader.Direction != Direction.None)
                {
                    previousDirection = reader.Direction;
                }
            }
        }
    }
}

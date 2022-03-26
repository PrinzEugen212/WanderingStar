using System;
using System.Threading;
using WanderingStar.Enums;
using WanderingStar.Interfaces;

namespace WanderingStar.Core
{
    public class Game
    {
        private GameParameters parameters;
        private Symbol symbol;
        private IDirection reader;
        private IRender render;
        private Direction previousDirection;

        public bool IsRunning { get; set; } = false;

        public Game(GameParameters parameters, Symbol symbol, IDirection reader, IRender render)
        {
            this.parameters = parameters;
            this.symbol = symbol;
            this.reader = reader;
            this.render = render;
        }

        public void StartDrawing()
        {
            IsRunning = true;
            while (IsRunning)
            {
                if (parameters.DeletePrevious)
                {
                    render.ClearPosition(symbol.Coordinate);
                }

                Coordinate newCoordinate = MoveSymbol(symbol.Coordinate);
                if (CheckCoordinate(newCoordinate))
                {
                    symbol.Coordinate = newCoordinate;
                }
                if (reader.Direction != Direction.None)
                {
                    previousDirection = reader.Direction;
                }
                render.WriteByCoordinates(symbol.Coordinate, symbol.symbol);
                Thread.Sleep(parameters.WaitTime);
            }
        }

        private bool CheckCoordinate(Coordinate newCoordinate)
        {
            return !(newCoordinate.X < 0 || newCoordinate.X >= render.MaxWidth || newCoordinate.Y < 0);
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
    }
}

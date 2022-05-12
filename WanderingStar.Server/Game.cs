using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WanderingStar.Core;
using WanderingStar.Core.Enums;

namespace WanderingStar.Server
{
    public class Game
    {
        private Socket listenSocket;
        private IPEndPoint listenEndPoint;
        private Coordinate coordinate;
        private Direction direction;
        private int waitTime;

        public bool IsRunning { get; set; } = false;

        public Game(Coordinate coordinateStart, int waitTime, string ipAddress, int port)
        {
            coordinate = coordinateStart;
            this.waitTime = waitTime;
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        }

        public void Start()
        {
            IsRunning = true;
            listenSocket.Bind(listenEndPoint);
            listenSocket.Listen(10);
            Process();
        }

        private void Process()
        {
            Socket handler = listenSocket.Accept();

            Task.Run(() =>
            {
                while (IsRunning)
                {
                    MoveSymbol();
                    byte[] data = Encoding.Unicode.GetBytes($"{coordinate.X} {coordinate.Y}");
                    handler.Send(data);
                    Thread.Sleep(waitTime);
                }
            });

            while (IsRunning)
            {
                StringBuilder builder = new StringBuilder();
                do
                {
                    byte[] data = new byte[256];
                    int bytes = handler.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (handler.Available > 0);

                if (builder.Length > 0)
                {
                    ChangeDirection(builder.ToString());
                }
            }
        }

        private void MoveSymbol()
        {
            Coordinate newCoordinate = new Coordinate(coordinate.X, coordinate.Y);
            switch (direction)
            {
                case Direction.Left: newCoordinate.X--; break;
                case Direction.Right: newCoordinate.X++; break;
                case Direction.Up: newCoordinate.Y--; break;
                case Direction.Down: newCoordinate.Y++; break;
                case Direction.None: break;
            }

            coordinate = newCoordinate;
        }

        private void ChangeDirection(string direction)
        {
            this.direction = Enum.Parse<Direction>(direction);
        }
    }
}

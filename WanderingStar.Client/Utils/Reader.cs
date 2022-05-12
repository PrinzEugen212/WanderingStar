using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WanderingStar.Core;
using WanderingStar.Core.Enums;
using WanderingStar.Interfaces;

namespace WanderingStar.Client.Utils
{
    public class Reader : IDisposable
    {
        private int waitTime;
        private Direction direction;
        private IKeyParser keyParser;
        private Socket listenSocket;
        private IPEndPoint listenEndPoint;
        private ConsoleRender render;

        public bool IsRunning { get; private set; } = false;

        public Reader(IKeyParser keyParser, ConsoleRender render, string ipAddress, int port, int waitTime)
        {
            direction = Direction.Right;
            this.keyParser = keyParser;
            this.render = render;
            this.waitTime = waitTime;
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            listenSocket.Connect(listenEndPoint);
        }

        public void Run()
        {
            IsRunning = true;
            SendDirection();

            Task.Run(() =>
            {
                while (IsRunning)
                {
                    byte[] data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    do
                    {
                        int bytes = listenSocket.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (listenSocket.Available > 0);

                    string[] coordinates = builder.ToString().Split(' ');
                    Coordinate coordinate = new Coordinate(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
                    render.Render(coordinate);
                    Thread.Sleep(waitTime);
                }
            });

            while (IsRunning)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                (CommandType type, Direction direction) parseResult = keyParser.Parse(key);
                direction = parseResult.direction;
                SendDirection();
            }
        }

        private void SendDirection()
        {
            byte[] data = Encoding.Unicode.GetBytes(direction.ToString());
            listenSocket.Send(data);
        }

        public void Dispose()
        {
            IsRunning = false;
            listenSocket.Close();
            listenSocket.Dispose();
        }
    }
}

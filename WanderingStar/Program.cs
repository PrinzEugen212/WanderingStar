using System;

namespace WanderingStar
{
    public class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            int x = 0, y = 0, waitTime;
            bool deletePrevious = true;
            Console.WriteLine("You can control the star usind WASD buttons");
            Console.WriteLine("Enter writing cooldown (in ms) and '1' if it not needed to delete previous symbol: ");
            while (true)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();
                    waitTime = int.Parse(command[0]);
                    if (int.Parse(command[1]) == 1)
                    {
                        deletePrevious = false;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Incorrect command - {ex.Message}");
                }
            }
            Console.CursorVisible = false;
            Console.Clear();
            while (true)
            {
                if (deletePrevious)
                {
                    Write(ref x, ref y, " ");
                }
                reader.Read();
                switch (reader.Direction)
                {
                    case Direction.Left: x--; break;
                    case Direction.Right: x++; break;
                    case Direction.Up: y--; break;
                    case Direction.Down: y++; break;
                }
                Write(ref x, ref y, "*");
                System.Threading.Thread.Sleep(waitTime);
            }
        }

        private static void Write(ref int x, ref int y, string output)
        {
            if (x < 0)
            {
                x = 0;
            }
            if (x >= Console.WindowWidth)
            {
                x = Console.WindowWidth - 1;
            }
            if (y < 0)
            {
                y = 0;
            }

            Console.SetCursorPosition(x, y);
            Console.Write(output);
        }
    }
}

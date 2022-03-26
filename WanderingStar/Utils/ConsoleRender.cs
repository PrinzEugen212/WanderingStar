using System;
using System.Threading;
using System.Threading.Tasks;
using WanderingStar.Core;
using WanderingStar.Interfaces;

namespace WanderingStar.Utils
{
    public class ConsoleRender : IRender
    {
        private IRenderable objectToRender;
        private int waitTime = 0;

        public ConsoleRender(IRenderable objectToRender, int waitTime)
        {
            this.objectToRender = objectToRender;
            objectToRender.NeedToClearPosition += ClearPosition;
            this.waitTime = waitTime;
        }

        public void StartRender()
        {
            while (objectToRender.RenderCondition)
            {
                objectToRender.ProcessNextIteration();
                if (CheckCoordinate())
                {
                    WriteByCoordinates();
                }
                else
                {
                    throw new Exception("Incorrect coordinate");
                }

                Thread.Sleep(waitTime);
            }
        }

        public int MaxWidth => Console.WindowWidth;

        public object ObjectToRender => objectToRender;

        public void WriteByCoordinates()
        {
            Console.SetCursorPosition(objectToRender.RenderCoordinate.X, objectToRender.RenderCoordinate.Y);
            Console.Write(objectToRender.ObjectToRender);
        }

        public void ClearPosition(object sender, EventArgs e)
        {
            if (CheckCoordinate())
            {
                Console.SetCursorPosition(objectToRender.RenderCoordinate.X, objectToRender.RenderCoordinate.Y);
                Console.Write(' ');
            }
            else
            {
                throw new Exception("Incorrect coordinate");
            }
        }

        private bool CheckCoordinate()
        {
            return !(objectToRender.RenderCoordinate.X < 0 || objectToRender.RenderCoordinate.X >= MaxWidth || objectToRender.RenderCoordinate.Y < 0);
        }
    }
}

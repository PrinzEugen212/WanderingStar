using System;
using WanderingStar.Core;

namespace WanderingStar.Interfaces
{
    public interface IRenderable
    {
        bool RenderCondition { get; }

        Object ObjectToRender { get; }

        Coordinate RenderCoordinate { get; }

        event EventHandler NeedToClearPosition;

        void ProcessNextIteration();
    }
}

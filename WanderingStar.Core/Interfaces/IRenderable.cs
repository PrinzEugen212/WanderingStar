using System;

namespace WanderingStar.Core.Interfaces
{
    public interface IRenderable
    {
        bool RenderCondition { get; }

        Object ObjectToRender { get; }

        ICoordinate RenderCoordinate { get; }

        event EventHandler NeedToClearPosition;

        void ProcessNextIteration();
    }
}

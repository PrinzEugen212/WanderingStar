using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

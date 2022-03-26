using System;
using WanderingStar.Core;

namespace WanderingStar.Interfaces
{
    public interface IRender
    {
        object ObjectToRender { get; }

        void ClearPosition(object sender, EventArgs eventArgs);

        void WriteByCoordinates();
    }
}

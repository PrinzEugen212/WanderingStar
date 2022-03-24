using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderingStar.Core;

namespace WanderingStar.Interfaces
{
    public interface IRender
    {
        int MaxWidth { get; }

        void ClearPosition(Coordinate coordinate);

        void WriteByCoordinates(Coordinate coordinate, char output);
    }
}

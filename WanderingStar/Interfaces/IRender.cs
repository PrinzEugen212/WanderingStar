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

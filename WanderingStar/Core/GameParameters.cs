namespace WanderingStar.Core
{
    public class GameParameters
    {
        public GameParameters() { }

        public GameParameters(int waitTime, bool deletePrevious)
        {
            WaitTime = waitTime;
            DeletePrevious = deletePrevious;
        }

        public int WaitTime { get; set; }
        public bool DeletePrevious { get; set; }
    }
}

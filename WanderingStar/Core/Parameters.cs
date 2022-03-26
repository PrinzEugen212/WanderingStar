namespace WanderingStar.Core
{
    public class Parameters
    {
        public Parameters() { }

        public Parameters(int waitTime, bool deletePrevious)
        {
            WaitTime = waitTime;
            DeletePrevious = deletePrevious;
        }

        public bool DeletePrevious { get; set; }

        public int WaitTime { get; set; }
    }
}

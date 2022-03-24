namespace WanderingStar
{
    public class StarParameters
    {
        public StarParameters() { }

        public StarParameters(int waitTime, bool deletePrevious)
        {
            WaitTime = waitTime;
            DeletePrevious = deletePrevious;
        }

        public int WaitTime { get; set; }
        public bool DeletePrevious { get; set; }
    }
}

using System;

namespace WanderingStar.Utils
{
    public class ReaderNotRunningException : Exception
    {
        public ReaderNotRunningException() : base("Reader is not running!")
        { }

        public ReaderNotRunningException(string message) : base(message)
        { }
    }
}

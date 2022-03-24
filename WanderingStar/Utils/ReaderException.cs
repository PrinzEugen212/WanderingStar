using System;

namespace WanderingStar
{
    public class ReaderNotRunningException : Exception
    {
        public ReaderNotRunningException() : base("Reader is not running!")
        { }

        public ReaderNotRunningException(string message) : base(message)
        { }
    }
}

using System;

namespace IMDbRESTAPI.CustomExceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException()
        {
        }

        public DataNotFoundException(string message)
            : base(message + " Not Found!")
        {
        }

        public DataNotFoundException(string message, Exception inner)
            : base(message + " Not Found!", inner)
        {
        }
    }
}
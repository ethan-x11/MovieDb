using System;

namespace IMDbRESTAPI.CustomExceptions
{
    public class EmptyDataException : Exception
    {
        public EmptyDataException()
        {
        }

        public EmptyDataException(string message)
            : base(message + " is Required!")
        {
        }

        public EmptyDataException(string message, Exception inner)
            : base(message + " is Required!", inner)
        {
        }
    }
}
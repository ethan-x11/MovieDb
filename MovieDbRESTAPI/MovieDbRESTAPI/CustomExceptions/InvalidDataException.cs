using System;

namespace IMDbRESTAPI.CustomExceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException()
        {
        }

        public InvalidDataException(string message)
            : base("Invalid " + message + "!")
        {
        }

        public InvalidDataException(string message, Exception inner)
            : base("Invalid " + message + "!", inner)
        {
        }
    }
}
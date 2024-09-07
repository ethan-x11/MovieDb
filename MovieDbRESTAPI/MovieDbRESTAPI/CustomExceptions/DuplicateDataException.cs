using System;

namespace IMDbRESTAPI.CustomExceptions
{
    public class DuplicateDataException : Exception
    {
        public DuplicateDataException()
        {
        }

        public DuplicateDataException(string message)
            : base(message + " Already Exists!")
        {
        }

        public DuplicateDataException(string message, Exception inner)
            : base(message + " Already Exists!", inner)
        {
        }
    }
}
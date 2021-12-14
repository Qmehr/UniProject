using System;

namespace Infrastructure.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message = "The values ​​entered in the account are not valid") : base(message)
        {
        }
    }
}
using System;

namespace Infrastructure.Exceptions
{
    public class InvalidCartIdException : Exception
    {
        public InvalidCartIdException(string message = "The value of the shopping cart ID is incorrect") : base(message)
        {
        }
    }
}
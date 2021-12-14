using System;

namespace Infrastructure.Exceptions
{
    public class InvalidProductIdException : Exception
    {
        public InvalidProductIdException(string message = "The product ID value is incorrect") : base(message)
        {
        }
    }
}
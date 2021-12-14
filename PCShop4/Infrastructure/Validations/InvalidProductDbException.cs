using System;

namespace Infrastructure.Exceptions
{
    public class InvalidProductDbException : Exception
    {
        public InvalidProductDbException(string message = "The product is not in the database") : base(message)
        {
        }
    }
}
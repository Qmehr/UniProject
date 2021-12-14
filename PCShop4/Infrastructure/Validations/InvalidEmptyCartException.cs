using System;

namespace Infrastructure.Exceptions
{
    public class InvalidEmptyCartException : Exception
    {
        public InvalidEmptyCartException(string message = "There is no shopping cart") : base(message)
        {
        }
    }
}
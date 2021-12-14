using System;

namespace Infrastructure.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message = "The amount is incorrect") : base(message)
        {
        }
    }
}
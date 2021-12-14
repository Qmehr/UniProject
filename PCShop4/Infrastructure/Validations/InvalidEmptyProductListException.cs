using System;

namespace Infrastructure.Exceptions
{
    public class InvalidEmptyProductListException : Exception
    {
        public InvalidEmptyProductListException(string message = "The product list is empty") : base(message)
        {
        }
    }
}
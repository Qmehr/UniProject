using System;

namespace Infrastructure.Exceptions
{
    public class InvalidEmptyPaymentTypeException : Exception
    {
        public InvalidEmptyPaymentTypeException(string message = "The payment method for this shopping cart is not defined") : base(message)
        {
        }
    }
}
using System;

namespace Infrastructure.Exceptions
{
    public class InvalidInstallmentMonthsException : Exception
    {
        public InvalidInstallmentMonthsException(string massage = "The product list is empty") : base(massage)
        {
            
        }
    }
}
using System;

namespace Infrastructure.Exceptions
{
    public class InvalidUserDbException : Exception
    {
        public InvalidUserDbException(string message = "کاربر در دیتابیس وجود ندارد") : base(message)
        {
        }
    }
}
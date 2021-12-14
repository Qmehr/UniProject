using System;

namespace DomainModel
{
    public abstract class Payment
    {
        public Guid Id = Guid.NewGuid();
        public abstract void PayMoney();
    }
}
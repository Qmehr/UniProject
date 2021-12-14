using System;

namespace DomainModel
{
    public class CashPayment : Payment
    {
        private Guid _id { get; }
        private DateTime _payTime { get; }
        public Amount _cash { get; set; }

        public CashPayment(Amount cash, DateTime payTime)
        {
            _id = Guid.NewGuid();
            _cash = cash;
            _payTime = payTime;
        }

        public override void PayMoney()
        {
            throw new Exception("Completed");
        }
    }
}
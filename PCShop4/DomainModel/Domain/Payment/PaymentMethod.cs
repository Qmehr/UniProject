using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public abstract class PaymentMethod
    {
        private Guid _id = Guid.NewGuid();
        public virtual PaymentMethodType PaymentMethodType { get; set; }
    }
}
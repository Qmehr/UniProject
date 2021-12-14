using Infrastructure.Enums;

namespace DomainModel
{
    public class PaymentCashMethod : PaymentMethod
    {
        public override PaymentMethodType PaymentMethodType { get; set; } = PaymentMethodType.CashMethod;
        public PaymentCashMethod(Cart cart)
        {
            cart.PaymentMethodType = this.PaymentMethodType;
        }
    }
}
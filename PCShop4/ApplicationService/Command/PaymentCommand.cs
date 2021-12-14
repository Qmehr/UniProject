using Infrastructure.Enums;

namespace ApplicationService.Command
{
    public class PaymentCommand
    {
        public int InstallmentCount { get; set; }
        public decimal PrePayment { get; set; }
        public PaymentMethodType PaymentMethod { get; set; }
    }
}
using System;
using ApplicationService.Command;
using ApplicationService.Interface;
using ApplicationService.Services;
using Infrastructure.Enums;

namespace Host.Controllers
{
    public class PaymentController
    {
        private readonly CartCommand _cartCommand;
        private readonly ICartService _iCartService;
        public PaymentController(CartCommand cartCommand, ICartService iCartService)
        {
            _cartCommand = cartCommand;
            _iCartService = iCartService;
        }
        public void GetPaymentType()
        {
            Console.WriteLine("\nWhat payment model do you choose? 1 - Cash    2 - Installment");
            var enteredMethodNumber = Convert.ToInt32(Console.ReadLine());
            switch (enteredMethodNumber)
            {
                case 1:
                    var cashPaymentMethod = new PaymentCommand() { PaymentMethod = PaymentMethodType.CashMethod };
                    new PaymentService(cashPaymentMethod, _cartCommand).SetCashPaymentMethodInCart();
                    _iCartService.CheckoutCart(_cartCommand, cashPaymentMethod);
                    break;
                case 2:
                    Console.WriteLine("\n1 - pay on one year + 12% Commission \n2 - pay on tow years + 18% Commission \n3 - pay on 3 years + 24% Commission \n0 - Back");
                    var enteredInstallmentNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nHow Much Money Do You Want Pay For PrePayment?");
                    var enteredPrePayment = Convert.ToDecimal(Console.ReadLine());
                    switch (enteredInstallmentNumber)
                    {
                        case 0:
                            GetPaymentType();
                            break;
                        case 1:
                            _cartCommand.PaymentType = PaymentMethodType.Installment12Months;
                            var paymentMethod12Months = new PaymentCommand() { InstallmentCount = 12, PrePayment = enteredPrePayment, PaymentMethod = PaymentMethodType.Installment12Months };
                            new PaymentService(paymentMethod12Months, _cartCommand).SetInstallmentMethodInCart(enteredPrePayment);
                            _iCartService.CheckoutCart(_cartCommand, paymentMethod12Months);
                            break;
                        case 2:
                            _cartCommand.PaymentType = PaymentMethodType.TwoYearsPayment;
                            var paymentMethod24Months = new PaymentCommand() { InstallmentCount = 24, PrePayment = enteredPrePayment, PaymentMethod = PaymentMethodType.TwoYearsPayment };
                            new PaymentService(paymentMethod24Months, _cartCommand).SetInstallmentMethodInCart(enteredPrePayment);
                            _iCartService.CheckoutCart(_cartCommand, paymentMethod24Months);
                            break;
                        case 3:
                            _cartCommand.PaymentType = PaymentMethodType.TheeyearsPayment;
                            var paymentMethod36Months = new PaymentCommand() { InstallmentCount = 36, PrePayment = enteredPrePayment, PaymentMethod = PaymentMethodType.TheeyearsPayment };
                            new PaymentService(paymentMethod36Months, _cartCommand).SetInstallmentMethodInCart(enteredPrePayment);
                            _iCartService.CheckoutCart(_cartCommand, paymentMethod36Months);
                            break;
                        default:
                            Console.WriteLine("Wrong Number");
                            GetPaymentType();
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("wrong number , try again ...");
                    GetPaymentType();
                    break;
            }
        }
    }
}
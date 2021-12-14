using System.Linq;
using ApplicationService.Command;
using ApplicationService.Interface;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;
using Repository.Database;

namespace ApplicationService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentCommand _paymentCommand;
        private readonly CartCommand _cartCommand;
        private DatabaseTable _databaseTable = DatabaseTable.GetInstance();
        public PaymentService(PaymentCommand paymentCommand, CartCommand cartCommand)
        {
            _paymentCommand = paymentCommand;
            _cartCommand = cartCommand;
        }
        public void SetCashPaymentMethodInCart()
        {
            if (_paymentCommand.PaymentMethod.Equals(PaymentMethodType.CashMethod))
            {
                var cart = _databaseTable.CartList.SingleOrDefault(i=>i.Id == _cartCommand.CartId);
                cart.PaymentMethod = new PaymentCashMethod(cart);
            }
        }
        public void SetInstallmentMethodInCart(decimal prePaymentDecimal)
        {
            var prePayment = new Amount(prePaymentDecimal);
            var cart = _databaseTable.CartList.SingleOrDefault(i => i.Id == _cartCommand.CartId);
            switch (_paymentCommand.PaymentMethod)
            {
                case PaymentMethodType.CashMethod:
                    cart.PaymentMethod = new PaymentCashMethod(cart);
                    break;
                case PaymentMethodType.Installment12Months:
                    cart.PaymentMethod = new LoanPayment(cart, 12, prePayment);
                    break;
                case PaymentMethodType.TwoYearsPayment:
                    cart.PaymentMethod = new LoanPayment(cart, 24, prePayment);
                    break;
                case PaymentMethodType.TheeyearsPayment:
                    cart.PaymentMethod = new LoanPayment(cart, 36, prePayment);
                    break;
                default:
                    throw new InvalidEmptyPaymentTypeException(); 
            }
        }
    }
}
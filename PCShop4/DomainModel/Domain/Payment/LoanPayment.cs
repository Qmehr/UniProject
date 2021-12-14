using System;
using System.Collections.Generic;
using Infrastructure.Enums;
using Infrastructure.Exceptions;

namespace DomainModel
{
    public class LoanPayment : PaymentMethod
    {
        public LoanPayment(Cart cart, int months, Amount prePayment)
        {
            _cart = cart;
            _months = months;
            PrePayCash = prePayment;
            SetPaymentMethodType();
        }
        public LoanPayment(Cart cart, Amount totalCost, Amount prePayCash, Amount commission, int months)
        {
            _totalCost = totalCost;
            _cart = cart;
            _months = months;
            PrePayCash = prePayCash;
            _commission = commission;
        }
        /// <summary>
        /// commission
        /// </summary>
        private Amount _commission { get; }
        /// <summary>
        /// PrePayment
        /// </summary>
        public Amount PrePayCash { get; }
        /// <summary>
        /// Total cost of cart
        /// </summary>
        private Amount _totalCost { get; }
        /// <summary>
        /// Current cart
        /// </summary>
        private Cart _cart { get; }
        /// <summary>
        /// Number of mounth
        /// </summary>
        private int _months { get; }
        /// <summary>
        /// List of Installment
        /// </summary>
        public List<Installment> Installments = new List<Installment>();

        public void SetPaymentMethodType()
        {
            switch (_months)
            {
                case 12:
                    _cart.PaymentMethodType = PaymentMethodType.Installment12Months;
                    break;
                case 24:
                    _cart.PaymentMethodType = PaymentMethodType.Installment12Months;
                    break;
                case 36:
                    _cart.PaymentMethodType = PaymentMethodType.Installment12Months;
                    break;
                default:
                    throw new InvalidInstallmentMonthsException();
            }
        }
        public void CalculateInstallments()
        {
            int addMonths = -1;
            for (int i = 1; i <= _months; i++)
            {
                var installment = new Installment(_months, _totalCost, _commission, DateTime.Today.AddMonths(addMonths++));
                Installments.Add(installment);
            }
            _cart.AddInstallments(Installments);
        }
    }
}
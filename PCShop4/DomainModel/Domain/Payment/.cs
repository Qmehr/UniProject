using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class PaymentInstallment : Payment
    {
        public PaymentInstallment(Cart cart, Amount totalCost, Amount prePayCash, Amount commission, int months)
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
        /// Prepayment
        /// </summary>
        public Amount PrePayCash { get; }
        /// <summary>
        /// Total cost of cart
        /// </summary>
        private Amount _totalCost { get; }
        /// <summary>
        /// Current shopping cart
        /// </summary>
        private Cart _cart { get; }
        /// <summary>
        /// Number of months
        /// </summary>
        private int _months { get; }
        /// <summary>
        /// Installment list
        /// </summary>
        public List<Installment> Installments = new List<Installment>();
        
        public override void PayMoney()
        {
            throw new Exception("Completed");
        }
    }
}
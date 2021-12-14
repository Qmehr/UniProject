using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid();
        }
        /// <summary>
        /// Shopping cart ID
        /// </summary>
        public Guid Id;
        /// <summary>
        /// Shopping Cart Name
        /// </summary>
        public string CartName { get; set; }
        /// <summary>
        /// List of products in the shopping cart
        /// </summary>
        public List<Product> Products = new List<Product>();
        /// <summary>
        /// Shopping cart type
        /// </summary>
        public CartStateType StateCartType { get; set; }
        /// <summary>
        /// payment type
        /// </summary>
        public PaymentMethodType PaymentMethodType { get; set; }
        /// <summary>
        /// Payment method
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }
        /// <summary>
        /// Payment
        /// </summary>

        private IEnumerable<CartState> stateHistory { get; set; }
        /// <summary>
        /// Shopping cart installment list
        /// </summary>
        public List<Installment> Installments { get; set; }
        public void AddInstallments(List<Installment> listInstallments)
        {
            foreach (var installment in listInstallments)
            {
                Installments.Add(installment);
            }
        }
        public void AddState(CartState cartState)
        {
            var temp = stateHistory.ToList();
            temp.Add(cartState);
            stateHistory = temp;
        }
        /// <summary>
        /// Making installments or paying in cash
        /// </summary>
        /// <param name="cart">Cart</param>
        /// <param name="Prepayment">PrePayment</param>
        public void CreatePayment(Cart cart, Amount Prepayment)
        {
            var cartPrice = cart.Products.Sum(i => i.Price.Value);
            switch (cart.PaymentMethodType)
            {
                case PaymentMethodType.CashMethod:
                    new CashPayment(new Amount(cartPrice), DateTime.Now);
                    break;
                case PaymentMethodType.Installment12Months:
                    new LoanPayment(cart, new Amount(cartPrice), Prepayment, new Amount(0.12m), 12).CalculateInstallments();
                    break;
                case PaymentMethodType.TwoYearsPayment:
                    new LoanPayment(cart, new Amount(cartPrice), Prepayment, new Amount(0.18m), 24).CalculateInstallments();
                    break;
                case PaymentMethodType.TheeyearsPayment:
                    new LoanPayment(cart, new Amount(cartPrice), Prepayment, new Amount(0.2m), 36).CalculateInstallments();
                    break;
            }
        }

    }
}
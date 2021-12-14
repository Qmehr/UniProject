using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{
    public class DomainService
    {
        private Cart Cart { get; }

        public DomainService(Cart cart)
        {
            Cart = cart;
        }
        public List<Installment> GetInstallments()
        {
            return Cart.Installments;
        }

        public decimal CartPrice()
        {
            var cartPrice = Cart.Products.Sum(i => i.Price.Value);
            return cartPrice;
        }
    }
}
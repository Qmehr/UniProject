using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Compeleted : CartState
    {
        private readonly Cart _cart;
        public Compeleted(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.Installment;
        }
        public override void ChecedOut()
        {
            _cart.AddState(new ChekedOut(_cart) { PlaceState = DateTime.Now });
        }
        public override void Removed()
        {
            _cart.AddState(new Compeleted(_cart) { PlaceState = DateTime.Now });
        }
    }
}
using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class Removed : CartState
    {
        private readonly Cart _cart;
        public Removed(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.Removed;
        }
        public override void Installment()
        {
            _cart.AddState(new Compeleted(_cart) { PlaceState = DateTime.Now });
        }
        public override void ChecedOut()
        {
            _cart.AddState(new ChekedOut(_cart) { PlaceState = DateTime.Now });
        }
        public override void Compeleted()
        {
            _cart.AddState(new SemiPaid(_cart) { PlaceState = DateTime.Now });
        }
    }
}
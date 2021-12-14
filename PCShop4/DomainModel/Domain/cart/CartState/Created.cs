using System;
using Infrastructure.Enums;

namespace DomainModel
{
    public class CartStateCreated : CartState
    {
        private readonly Cart _cart;
        public CartStateCreated(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.Created;
        }
        public override void Created()
        {
            _cart.AddState(new CartStateCreated(_cart) { PlaceState = DateTime.Now });
        }
        public override void Removed()
        {
            _cart.AddState(new Removed(_cart) {PlaceState = DateTime.Now});
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
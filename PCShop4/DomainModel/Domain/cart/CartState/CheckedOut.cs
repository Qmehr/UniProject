using Infrastructure.Enums;

namespace DomainModel
{
    public class ChekedOut : CartState
    {
        private readonly Cart _cart;
        public ChekedOut(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.CheckedOut;
        }
    }
}
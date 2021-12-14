using Infrastructure.Enums;

namespace DomainModel
{
    public class SemiPaid : CartState
    {
        private readonly Cart _cart;
        public SemiPaid(Cart cart)
        {
            _cart = cart;
            _cart.StateCartType = CartStateType.Compeleted;
        }
    }
}
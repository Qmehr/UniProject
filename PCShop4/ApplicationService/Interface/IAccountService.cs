using System;
using ApplicationService.Command;

namespace ApplicationService.Interface
{
    public interface IAccountService
    { 
        void UserLogin(AccountCommand accountCommand);
        void AddCartToCartList(AccountCommand accountCommand, Guid cartId);
        void RemoveCartFromCartList(AccountCommand accountCommand, Guid cartId);
    }
}
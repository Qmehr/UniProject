using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationService.Command;
using ApplicationService.Interface;
using DomainModel;
using Infrastructure.Exceptions;
using Repository;
using Repository.Verifications;

namespace ApplicationService.Services
{
    public class AccountService : IAccountService
    {
        private static readonly GetOnlyRepository Repository = new GetOnlyRepository();
        private readonly List<User> _userList = Repository.UsersList();
        private bool UserVerification(AccountCommand accountCommand)
        {
            new AccountVerification(new User() { Username = accountCommand.Username, Password = accountCommand.Password }).UserVerification();
            return true;
        }
        public void UserLogin(AccountCommand accountCommand)
        {
            if (!UserVerification(accountCommand))
                throw new InvalidUserException();
        }
        public void AddCartToCartList(AccountCommand accountCommand, Guid cartId)
        {
            var user = _userList.SingleOrDefault(a=>a.Username == accountCommand.Username);
            if (user != null)
                user.AddCart(cartId);
        }
        public void RemoveCartFromCartList(AccountCommand accountCommand, Guid cartId)
        {
            var user = _userList.SingleOrDefault(a => a.Username == accountCommand.Username);
            if (user != null) 
                user.RemoveCart(cartId);
        }
    }
}
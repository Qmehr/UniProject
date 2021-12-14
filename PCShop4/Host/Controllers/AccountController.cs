using System;
using ApplicationService.Command;
using ApplicationService.Services;
namespace Host.Controllers
{
    public class AccountController
    {
        private AccountCommand _accountCommand;
        public AccountController(AccountCommand accountCommand)
        {
            _accountCommand = accountCommand;
        }
        public void View()
        {
            Console.WriteLine("\nLogin");
            Console.WriteLine("\nPlease Enter Your Username");
            string username = Console.ReadLine();
            Console.WriteLine("Please Enter Your Password");
            string password = Console.ReadLine();
            _accountCommand.Username = username;
            _accountCommand.Password = password;
            CheckUser(_accountCommand);
            _accountCommand = new AccountCommand();
        }
        public void CheckUser(AccountCommand accountCommand)
        {
            accountCommand.Validate();
            new AccountService().UserLogin(accountCommand);
        }
        public void Login()
        {
            Console.WriteLine("Login Successful!");
        }
    }
}
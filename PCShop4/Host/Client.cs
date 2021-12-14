using ApplicationService.Command;
using ApplicationService.Services;
using Host.Controllers;

namespace Host
{
    public class Client
    {
        public void Program()
        {
            var accountCommand = new AccountCommand();
            var productCommand = new ProductCommand();
            var cartCommand = new CartCommand();
            var paymentCommand = new PaymentCommand();
            var cartService = new CartService();
            var accountController = new AccountController(accountCommand);
            accountController.View();
            accountController.Login();
            var cartController = new CartController(cartService, accountCommand, productCommand, cartCommand, paymentCommand);
            
            cartController.DisplayCartPanel();
        }
    }
}
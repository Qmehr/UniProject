using System;
using ApplicationService.Command;
using ApplicationService.Interface;
using ApplicationService.Services;
using DomainModel;

namespace Host.Controllers
{
    public class CartController
    {
        private readonly ICartService _iCartService;
        private readonly AccountCommand _accountCommand;
        private readonly CartCommand _cartCommand;
        private readonly PaymentCommand _paymentCommand;
        private readonly ProductCommand _productCommand;
        public CartController(ICartService iCartService, AccountCommand accountCommand, ProductCommand productCommand, CartCommand cartCommand, PaymentCommand paymentCommand)
        {
            _iCartService = iCartService;
            _accountCommand = accountCommand;
            _productCommand = productCommand;
            _cartCommand = cartCommand;
            _paymentCommand = paymentCommand;
        }
        public string GetCartName()
        {
            Console.WriteLine("Enter Your Selected Cart Name ...");
            var cartName = Console.ReadLine();
            return cartName;
        }
        public void DisplayCartPanel()
        {
            Console.WriteLine("Cart  \n" +
                              "1 - Submit A New Cart \n" +
                              "2 - Remove A Cart\n" +
                              "3 - Add A New Product To Your Cart \n" +
                              "4 - Remove A Product From Your Cart \n" +
                              "5 - Show Products In One Cart \n" +
                              "6 - Show Carts \n" +
                              "7 - See Cart Price\n" +
                              "8 - CheckOut Cart");
            var enteredNumber = Convert.ToInt32(Console.ReadLine());
            switch (enteredNumber)
            {
                case 1:
                    var newCartName = GetCartName();
                    var cartGuid = _iCartService.AddNewCart(_accountCommand, newCartName);
                    _cartCommand.CartId = cartGuid;
                    DisplayCartPanel();
                    break;
                case 2:
                    var cartNameForRemove = GetCartName();
                    _cartCommand.CartName = cartNameForRemove;
                    _iCartService.RemoveCart(_accountCommand, _cartCommand);
                    DisplayCartPanel();
                    break;
                case 3:
                    var cartNameForAddProductToCart = GetCartName();
                    _cartCommand.CartName = cartNameForAddProductToCart;
                    ShowProductList();
                    DisplayCartPanel();
                    break;
                case 4:
                    var cartNameForRemoveProductFromCart = GetCartName();
                    _cartCommand.CartName = cartNameForRemoveProductFromCart;
                    Console.WriteLine("Enter ProductID");
                    var enteredProductId = Convert.ToInt32(Console.ReadLine());
                    _productCommand.ProductId = enteredProductId;
                    _iCartService.RemoveProductFromCart(_cartCommand, _productCommand);
                    DisplayCartPanel();
                    break;
                case 5:
                    var cartNameForShowProducts = GetCartName();
                    _cartCommand.CartName = cartNameForShowProducts;
                    var cartDto = _iCartService.ShowCartItem(_cartCommand);
                    foreach (var product in cartDto.ProductDtos)
                        Console.WriteLine(product.Display());
                    DisplayCartPanel();
                    break;
                case 6:
                    var cartList = _iCartService.ShowCarts();
                    foreach (var cart in cartList)
                        Console.WriteLine(cart.Name);
                    DisplayCartPanel();
                    break;
                case 7:
                    var cartNameForTotalCost = GetCartName();
                    _cartCommand.CartName = cartNameForTotalCost;
                    var totalPriceCart = _iCartService.CartPriceCalculator(_cartCommand);
                    Console.WriteLine("TotalPrice : " + totalPriceCart + " MillionToman");
                    DisplayCartPanel();
                    break;
                case 8:
                    var cartNameForCheckout = GetCartName();
                    _cartCommand.CartName = cartNameForCheckout;
                    new PaymentController(_cartCommand, _iCartService).GetPaymentType();
                    var installmentDtos = _iCartService.GetInstallmentDtos(_cartCommand);
                    for (var index = 0; index < installmentDtos.Count; index++)
                    {
                        var installmentDto = installmentDtos[index];
                        Console.WriteLine(index+1 + " - | " + installmentDto._price + " | " +
                                          installmentDto._payDate);
                    }
                    DisplayCartPanel();
                    break;
                default:
                    Console.WriteLine("Your Entered Number Is Wrong ... Try Again ...");
                    DisplayCartPanel();
                    break;
            }
        }
        public void ShowProductList()
        {
            while (true)
            {
                var productService = new ProductService();
                var productController = new ProductController(productService, _cartCommand);

                Console.WriteLine("\n 1 - Back To Panel \n 2 - CPU \n 3 - Ram \n 4 - GraphicCard \n 5 - HDD  ");
                var enteredNumberStr = Console.ReadLine();
                int selectedItemId = Convert.ToInt32(enteredNumberStr);
                switch (selectedItemId)
                {
                    case 1:
                        DisplayCartPanel();
                        break;
                    case 2:
                        productController.Display(productService.GetCpuProducts());
                        break;
                    case 3:
                        productController.Display(productService.GetRamProducts());
                        break;
                    case 4:
                        productController.Display(productService.GetGraphicCardProducts());
                        break;
                    case 5:
                        productController.Display(productService.GetHddProducts());
                        break;
                    default:
                        Console.WriteLine("Wrong Number...");
                        continue;
                }
                break;
            }
        }
    }
}
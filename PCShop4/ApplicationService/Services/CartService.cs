using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationService.Command;
using ApplicationService.Dtos;
using ApplicationService.Interface;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;
using DatabaseTable = Repository.Database.DatabaseTable;

namespace ApplicationService.Services
{
    public class CartService : ICartService
    {
        public static readonly DatabaseTable _database = DatabaseTable.GetInstance();
        readonly List<Product> _productsList = _database.ProductsList;

        public Cart Cart { get; set; }
        public CartDto ShowCartItem(CartCommand cartCommand)
        {
            var _cartList = _database.CartList;
            var cart = _cartList.FirstOrDefault(c => c.CartName == cartCommand.CartName);
            var cartDto = new CartDto();
            foreach (var product in cart.Products)
            {
                var item = new ProductDto() { ProductId = product.ProductId, Name = product.Device.Name, Model = product.Device.Model, Price = product.Price };
                cartDto.ProductDtos.Add(item);
            }
            return cartDto;
        }
        public List<CartDto> ShowCarts()
        {
            var cartList = _database.CartList;
            var cart = cartList;
            var cartDtos = new List<CartDto>();
            foreach (var c in cart)
            {
                var item = new CartDto() { Name = c.CartName };
                cartDtos.Add(item);
            }
            return cartDtos;
        }

        public Guid AddNewCart(AccountCommand accountCommand, string name)
        {
            var cartList = _database.CartList;
            cartList.Add(new Cart() { CartName = name, StateCartType = CartStateType.Created });
            var cart = cartList.SingleOrDefault(i => i.Id == cartList.FirstOrDefault(j => j.CartName == name).Id);
            if (cart != null)
                new AccountService().AddCartToCartList(accountCommand, cart.Id);
            return cart.Id;
        }
        public void RemoveCart(AccountCommand accountCommand, CartCommand cartCommand)
        {
            var _cartList = _database.CartList;
            var cart = _cartList.FirstOrDefault(i => i.Id == cartCommand.CartId);
            var cartSelected = _cartList.FindIndex(i => cart != null && i.Id == cart.Id);
            _cartList.RemoveAt(cartSelected);
            if (cart != null)
                new AccountService().RemoveCartFromCartList(accountCommand, cart.Id);
        }
        public void AddProductsToCart(CartCommand cartCommand, List<ProductCommand> productsCommand)
        {
            var cartList = _database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id == cartCommand.CartId);
            var cartSelected = cartList.SingleOrDefault(i => cart != null && i.Id == cart.Id);
            var products = new List<Product>();
            foreach (var productCommand in productsCommand)
            {
                var product = _productsList.SingleOrDefault(i => i.ProductId == productCommand.ProductId);
                products.Add(product);
            }
            if (cartSelected != null)
                foreach (var product in products)
                {
                    cartSelected.Products.Add(product);
                }
            else
            {
                var newCart = new Cart { CartName = $"{cartCommand.CartName}" };
                cartList.Add(newCart);
                newCart.AddState(new CartStateCreated(newCart));
                foreach (var product in products)
                {
                    newCart.Products.Add(product);
                }
            }
        }
        public void RemoveProductFromCart(CartCommand cartCommand, ProductCommand productCommand)
        {
            var _cartList = _database.CartList;
            var product = _productsList.FirstOrDefault(i => i.ProductId == productCommand.ProductId);
            var cart = _cartList.FirstOrDefault(i => i.Id == cartCommand.CartId);
            if (cart != null)
            {
                var selectedItemIndex = cart.Products.FindIndex(i => product != null && i.ProductId == product.ProductId);
                _cartList.SingleOrDefault(i => i.Id == cart.Id)?.Products.RemoveAt(selectedItemIndex);
                cart.AddState(new Removed(cart));
            }
        }
        public decimal CartPriceCalculator(CartCommand cartCommand)
        {
            decimal totalPrices = decimal.Zero;
            var cartList = _database.CartList;
            var cart = cartList.SingleOrDefault(i => i.Id == cartCommand.CartId);
            var cartSelected = cartList.SingleOrDefault(i => cart != null && i.Id == cart.Id);
            var products = new List<Product>();
            if (cartSelected != null)
                foreach (var product in cartSelected.Products)
                {
                    totalPrices += product.Price.Value;
                }
            return totalPrices;
        }
        public void CheckoutCart(CartCommand cartCommand, PaymentCommand paymentCommand)
        {
            var _cartList = _database.CartList;
            var cart = _cartList.SingleOrDefault(i => i.Id.Equals(cartCommand.CartId));
            if (cart != null)
            {
                var productsCount = cart.Products.Count;
                if (productsCount > 0)
                {
                    if (cart.PaymentMethodType.Equals(PaymentMethodType.CashMethod))
                    {
                        paymentCommand.PrePayment = CartPriceCalculator(cartCommand);
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else if (cart.PaymentMethodType.Equals(PaymentMethodType.Installment12Months))
                    {
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else if (cart.PaymentMethodType.Equals(PaymentMethodType.TwoYearsPayment))
                    {
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else if (cart.PaymentMethodType.Equals(PaymentMethodType.TheeyearsPayment))
                    {
                        cart.CreatePayment(cart, new Amount(paymentCommand.PrePayment));
                    }
                    else
                    {
                        throw new InvalidEmptyPaymentTypeException();

                    }
                }
                else
                    throw new InvalidEmptyProductListException();
            }
            else
                throw new InvalidEmptyCartException();
        }
        public List<InstallmentDto> GetInstallmentDtos(CartCommand cartCommand)
        {
            var cart = _database.CartList.SingleOrDefault(c => c.Id == cartCommand.CartId);
            cart.Installments = new DomainService(cart).GetInstallments();
            List<InstallmentDto> installmentDtos = new List<InstallmentDto>();
            foreach (var installment in cart.Installments)
            {
                installmentDtos.Add(new InstallmentDto(installmentCount: installment._installmentCount,
                    price: installment._price.Value, installment._payDate));
            }
            return installmentDtos;
        }
    }
}
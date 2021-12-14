using System;
using System.Collections.Generic;
using ApplicationService.Command;
using ApplicationService.Dtos;
using DomainModel;

namespace ApplicationService.Interface
{
    public interface ICartService
    {
        CartDto ShowCartItem(CartCommand cartCommand);
        List<CartDto> ShowCarts();
        Guid AddNewCart(AccountCommand accountCommand, string Name);
        void RemoveCart(AccountCommand accountCommand, CartCommand cartCommand);
        void AddProductsToCart(CartCommand cartCommand, List<ProductCommand> productsCommand);
        void RemoveProductFromCart(CartCommand cartCommand, ProductCommand productCommand);
        void CheckoutCart(CartCommand cartCommand, PaymentCommand paymentCommand);
        decimal CartPriceCalculator(CartCommand cartCommand);
        List<InstallmentDto> GetInstallmentDtos(CartCommand cartCommand);
    }
}
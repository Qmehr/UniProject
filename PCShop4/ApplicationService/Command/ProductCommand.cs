using System.Collections.Generic;
using ApplicationService.Services;
using Infrastructure.Exceptions;

namespace ApplicationService.Command
{
    public class ProductCommand : CommandBase
    {
        public int ProductId { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(ProductId.ToString()))
                throw new InvalidProductIdException();
        }
        public void AddToProducts(CartCommand cartCommand, ProductCommand productCommand)
        {
            var productCommandList = new List<ProductCommand> {productCommand};
            new CartService().AddProductsToCart(cartCommand, productCommandList);
        }
    }
}
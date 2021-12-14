using System;
using System.Collections.Generic;
using ApplicationService.Command;
using ApplicationService.Dtos;
using ApplicationService.Interface;

namespace Host.Controllers
{
    public class ProductController
    {
        private readonly IProductService _iProductService;
        private readonly CartCommand _cartCommand;
        public ProductController(IProductService iProductService, CartCommand cartCommand)
        {
            _iProductService = iProductService;
            _cartCommand = cartCommand;
        }
        public void Display(List<ProductDto> productDto)
        {
            foreach (var product in productDto)
            {
                Console.WriteLine("ProductID : " + product.ProductId + " Name : " + product.Name + " Model : " + product.Model + " Price : " + product.Price.Value + " MillionToman");
            }
            Console.WriteLine("Enter Product ID");
            var enteredId = Convert.ToInt32(Console.ReadLine());
            RequestProduct(enteredId);
        }
        public void RequestProduct(int id)
        {
            var registeredProduct = _iProductService.RegisterProduct(new ProductCommand() {ProductId = id});
            Console.WriteLine(registeredProduct.Device.Name + " | " + registeredProduct.Device.Model + "Selected");
            var productCommand = new ProductCommand() {ProductId = registeredProduct.ProductId};
            AddToProducts(_cartCommand, productCommand);
        }
        public void AddToProducts(CartCommand cartCommand ,ProductCommand productCommand)
        {
            var product = new ProductCommand();
            product.AddToProducts(_cartCommand, productCommand);
        }
    }
}
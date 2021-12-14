using System.Collections.Generic;
using System.Linq;
using ApplicationService.Command;
using ApplicationService.Dtos;
using ApplicationService.Interface;
using DomainModel;
using Infrastructure.Enums;
using Infrastructure.Exceptions;
using Repository.Database;

namespace ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private static readonly DatabaseTable database = DatabaseTable.GetInstance();
        private readonly List<Product> _productsList = database.ProductsList;

        public Product RegisterProduct(ProductCommand command)
        {
            var product = _productsList.SingleOrDefault(i => i.ProductId == command.ProductId);
            if (product == null)
                throw new InvalidProductDbException();
            return product;
        }
        public List<ProductDto> GetAllProducts()
        {
            var result = new List<ProductDto>();
            for (int i = 0; i <= _productsList.Count; i++)
            {
                var product = _productsList.SingleOrDefault(j => j.ProductId - 1 == i);
                if (product != null)
                    result.Add(new ProductDto()
                    {
                        ProductId = product.ProductId,
                        Name = product.Device.Name,
                        Model = product.Device.Model,
                        Price = product.Price
                    });
            }

            return result;
        }

        public List<ProductDto> GetCpuProducts()
        {
            var result = new List<ProductDto>();
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Cpu).ToList();
            for (var index = 0; index < productsList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productsList[index].ProductId,
                    Name = productsList[index].Device.Name,
                    Model = productsList[index].Device.Model,
                    Price = productsList[index].Price
                });
            }
            return result;
        }

        public List<ProductDto> GetRamProducts()
        {
            var result = new List<ProductDto>();
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Ram).ToList();
            for (var index = 0; index < productsList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productsList[index].ProductId,
                    Name = productsList[index].Device.Name,
                    Model = productsList[index].Device.Model,
                    Price = productsList[index].Price
                });
            }

            return result;
        }

        public List<ProductDto> GetGraphicCardProducts()
        {
            var result = new List<ProductDto>();
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.GraphicCard).ToList();
            for (var index = 0; index < productsList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productsList[index].ProductId,
                    Name = productsList[index].Device.Name,
                    Model = productsList[index].Device.Model,
                    Price = productsList[index].Price
                });
            }

            return result;
        }

        public List<ProductDto> GetHddProducts()
        {
            var result = new List<ProductDto>();
            var productsList = _productsList.Where(j => j.Device.DeviceType == DeviceType.Hdd).ToList();
            for (var index = 0; index < productsList.Count(); index++)
            {
                result.Add(new ProductDto()
                {
                    ProductId = productsList[index].ProductId,
                    Name = productsList[index].Device.Name,
                    Model = productsList[index].Device.Model,
                    Price = productsList[index].Price
                });
            }

            return result;
        }

        
    }
}
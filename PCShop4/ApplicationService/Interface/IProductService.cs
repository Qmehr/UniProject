using System.Collections.Generic;
using ApplicationService.Command;
using ApplicationService.Dtos;
using DomainModel;

namespace ApplicationService.Interface
{
    public interface IProductService
    {
        List<ProductDto> GetAllProducts();
        Product RegisterProduct(ProductCommand command);
    }
}
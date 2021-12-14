using System;
using System.Collections.Generic;
using DomainModel;

namespace ApplicationService.Dtos
{
    public class CartDto
    {
        public Guid CartId { get; set; }
        public string Name { get; set; }
        public Amount TotalPrice { get; set; }
        public List<ProductDto> ProductDtos { get; set; }
    }
}
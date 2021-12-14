using ApplicationService.Interface;
using DomainModel;

namespace ApplicationService.Dtos
{
    public class ProductDto : IDtoBase
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public Amount Price { get; set; }
        public string Display()
        {
            return $"Id = {ProductId} | Name = {Name} | Model : {Model} | Price : {Price.Value} MillionToman";
        }
    }
}
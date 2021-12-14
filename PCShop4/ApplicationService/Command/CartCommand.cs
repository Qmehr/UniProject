using System;
using Infrastructure.Enums;
using Infrastructure.Exceptions;

namespace ApplicationService.Command
{
    public class CartCommand : CommandBase
    {
        public Guid CartId { get; set; }
        public string CartName { get; set; }
        public PaymentMethodType PaymentType { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(CartId.ToString()))
                throw new InvalidCartIdException();
        }
    }
}
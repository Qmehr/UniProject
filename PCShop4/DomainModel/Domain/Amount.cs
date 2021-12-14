using Infrastructure.Exceptions;

namespace DomainModel
{
    public class Amount
    {
        public decimal Value{ get; set; }
        /// <summary>
        /// amount of Decimal
        /// </summary>
        public Amount(decimal value)
        {
            Validation(value);
            Value = value;
        }
        private void Validation(decimal value) 
        {
            if (value < 0)
                throw new InvalidAmountException();
        }
        public void MultipleAmount(Amount value)
        {
            Value *= value.Value;
        }
        
        public void DivisionAmount(Amount value)
        {
            var a = Value / value.Value;
            Value = a;
        }
    }
}

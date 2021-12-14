using System;

namespace ApplicationService.Dtos
{
    public class InstallmentDto
    {
        public int _installmentCount;
        public decimal _price;
        public DateTime _payDate;
        public InstallmentDto(int installmentCount, decimal price, DateTime payDate)
        {
            _installmentCount = installmentCount;
            _price = price;
            _payDate = payDate;
        }
    }
}
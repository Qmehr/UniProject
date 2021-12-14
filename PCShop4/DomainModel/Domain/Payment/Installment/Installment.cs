using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{
    public class Installment
    {
        public Installment(int installmentCount, Amount price, Amount commission, DateTime payDate)
        {
            _installmentCount = installmentCount;
            _price = price;
            CommissionCalculator(commission);
            _payDate = payDate;
            _price.DivisionAmount(new Amount(Convert.ToDecimal(installmentCount)));
        }
        /// <summary>
        /// زمان پرداخت قسط
        /// </summary>
        public DateTime _payDate { get; }
        /// <summary>
        /// مبلغ هر قسط
        /// </summary>
        public Amount _price { get; }
        /// <summary>
        /// تعداد اقساط
        /// </summary>
        public int _installmentCount;
        /// <summary>
        /// وضعیت قسط
        /// </summary>
        public InstallmentState InstallmentState
        {
            get => _installmentStateHistory.LastOrDefault();
            private set { }
        }
        /// <summary>
        /// لیست وضعیت های اقساط
        /// </summary>
        public IEnumerable<InstallmentState> _installmentStateHistory { get; private set; } = new List<InstallmentState>();
        /// <summary>
        /// افزودن وضعیت به وضعیت های پرداخت اقساط
        /// </summary>
        public void AddState(InstallmentState installmentState)
        {
            var temp = _installmentStateHistory.ToList();
            temp.Add(installmentState);
            _installmentStateHistory = temp;
        }
        /// <summary>
        /// محاسبه ی کارمزد اقساط در مبلغ هر قسط
        /// </summary>
        /// <param name="commission"></param>
        public void CommissionCalculator(Amount commission)
        {
            switch (commission.Value)
            {
                case 0.12m:
                    _price.MultipleAmount(new Amount(0.12m));
                    break;
                case 0.18m:
                    _price.MultipleAmount(new Amount(0.18m));
                    break;
                case 0.24m:
                    _price.MultipleAmount(new Amount(0.24m));
                    break;
            }
        }
    }
}
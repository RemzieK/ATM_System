using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Fees
{
    public class FivePercentFee : IFeeStrategy
    {
        public decimal CalculateFee(decimal amount)
        {
            return amount * 0.05m;
        }
        public decimal GetFeePercentage()
        {
            return 5m;
        }
    }
}

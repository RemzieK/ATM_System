using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Fees
{
    public class TenPercentFee : IFeeStrategy
    {
        public decimal CalculateFee(decimal amount)
        {
           return amount * 0.10m;
        }
        public decimal GetFeePercentage()
        {
            return 10m; 
        }
    }
}

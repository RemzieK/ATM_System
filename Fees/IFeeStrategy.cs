using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Fees
{
    public interface IFeeStrategy
    {
        public decimal CalculateFee(decimal amount);
        decimal GetFeePercentage();
    }
}

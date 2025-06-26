using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Fees
{
    public class ThreePercentFee:IFeeStrategy
    {
        public decimal CalculateFee(decimal amount)
        {
          return amount * 0.03m; 
        }
        public decimal GetFeePercentage()
        {
            return 3m; 
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Fees
{
    public static class FeeSelection
    {
        public static IFeeStrategy SelectFeeStrategy(decimal amount)
        {
            if (amount <= 100)
            {
                return new ThreePercentFee();
            }
            else if (amount <= 1000)
            {
                return new FivePercentFee();
            }
            else
            {
                return new TenPercentFee();
            }
        }
    }
}

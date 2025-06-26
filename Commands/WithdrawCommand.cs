using Bank.Accounts;
using Bank.ATM;
using Bank.Fees;
using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    public class WithdrawCommand : ICommand
    {
        private readonly IAccount _account;
        private readonly decimal _amount;

        public WithdrawCommand( IAccount account, decimal amount) 
        {
            _account = account;
            _amount = amount;
        }
        public void Execute()
        {
            try
            {
                if (_amount <= 0)
                {
                    throw new ArgumentException("Amount to withdraw must be greater than zero.");
                }
                IFeeStrategy feeStrategy = FeeSelection.SelectFeeStrategy(_amount);

                decimal fee = feeStrategy.CalculateFee(_amount);
                decimal totalAmount = _amount + fee;
              
                decimal feePercentage = feeStrategy.GetFeePercentage();

                if (totalAmount > _account.CheckBalance())
                {
                    throw new InvalidOperationException("Insufficient funds.");
                }
                _account.UpdateBalance(-totalAmount);
                Console.WriteLine($"Withdrawn {_amount} from your account. Fee: {fee}. Fee Percentage: {feePercentage}%");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error withdrawing: {ex.Message}");
            }
        }
    }
}

using Bank.Accounts;
using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    public class CheckBalanceCommand : ICommand
    {
        private readonly IAccount _account;

        public CheckBalanceCommand(IAccount account)
        {
            _account=account;
        }

        public void Execute()
        {
            try
            {
                decimal balance = _account.CheckBalance();
                Console.WriteLine($"Your current balance is: {balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking balance: {ex.Message}");
            }
        }
    }
}

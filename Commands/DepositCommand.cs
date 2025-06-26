using Bank.Accounts;
using Bank.ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    public class DepositCommand : ICommand
    {
        private readonly ATMSystem _atm;
        private readonly IAccount _account;
        private readonly decimal _amount;

        public DepositCommand(ATMSystem atm, IAccount account, decimal amount)
        {
            _atm = atm;
            _account = account;
            _amount = amount;
        }

        public void Execute()
        {
            try
            {
                if (_amount <= 0)
                {
                    throw new ArgumentException("Amount to deposit must be greater than zero.");
                }

                _account.UpdateBalance(_amount);
                Console.WriteLine($"Deposited {_amount} to your account.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error depositing: {ex.Message}");
            }
        }
    }
}

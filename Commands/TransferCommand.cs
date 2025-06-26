using Bank.Accounts;
using Bank.ATM;
using Bank.Bank;
using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    public  class TransferCommand:ICommand
    {
        private readonly IAccount _senderAccount;
        private readonly IAccount _recipientAccount;
        private readonly decimal _amount;
        private readonly string _senderName;
        private readonly string _recipientName;
        public TransferCommand(IAccount senderAccount, IAccount recipientAccount, decimal amount, string senderName, string recipientName)
        {
            _senderAccount = senderAccount;
            _recipientAccount = recipientAccount;
            _amount = amount;
            _senderName = senderName;
            _recipientName = recipientName;
        }
        public void Execute()
        {
            try
            {
                if (_amount <= 0)
                {
                    throw new ArgumentException("Amount to transfer must be greater than zero.");
                }

                if (_amount > _senderAccount.CheckBalance())
                {
                    throw new InvalidOperationException("Not enough money to send.");
                }

                _senderAccount.UpdateBalance(-_amount);
                _recipientAccount.UpdateBalance(_amount);

                Console.WriteLine($"Transferred {_amount} from account {_senderName} to account {_recipientName}.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error transferring: {ex.Message}");
            }
        }
    }
}

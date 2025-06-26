using Bank.States;
using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Accounts
{
    public class Account : IAccount
    {
        public string AccountId { get; }
        public decimal Balance { get; private set; }
        public Account()
        {
            AccountId = Guid.NewGuid().ToString();
            Balance = 0;
        }
        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }
        public decimal CheckBalance()
        {
            return Balance;
        }
    }
}

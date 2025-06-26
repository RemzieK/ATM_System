using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Accounts
{
    public interface IAccount
    {
        string AccountId { get; }
        decimal Balance { get; }
        void UpdateBalance(decimal amount);
        decimal CheckBalance();
    }
}

using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Accounts
{
    public class BonusPercentAccount : IAccount
    {
        private readonly IAccount _account;
        private const decimal BonusRate = 0.01m;
        private DateTime _lastBonusApplication;
        public BonusPercentAccount(IAccount account)
        {
            _account = account;
            _lastBonusApplication = DateTime.Now;
        }
        public string AccountId => _account.AccountId;
        public decimal Balance
        {
            get
            {
                ApplyMonthlyBonus();
                return _account.Balance;
            }
        }
        public void UpdateBalance(decimal amount)
        {
            _account.UpdateBalance(amount);
        }
        public decimal CheckBalance()
        {
            ApplyMonthlyBonus();
            return _account.CheckBalance();
        }
        private void ApplyMonthlyBonus()
        {
            DateTime currentDateTime = DateTime.Now;
            if (currentDateTime.Month != _lastBonusApplication.Month || currentDateTime.Year != _lastBonusApplication.Year)
            {
                decimal bonusAmount = _account.CheckBalance() * BonusRate;
                _account.UpdateBalance(bonusAmount);
                _lastBonusApplication = currentDateTime; 
            }
        }
    }
}

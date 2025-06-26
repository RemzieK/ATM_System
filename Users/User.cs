using Bank.Accounts;
using Bank.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Users
{
    public class User : IUser
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Account Account { get; private set; }
        public IUserState UserState { get; set; }
        public int WithdrawalsThisMonth { get; set; } = 0;
        private DateTime ResetWithdrawal { get; set; }

        public User(string name, Account account, IUserState initialState)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Account = account;
            UserState = initialState;
            ResetWithdrawal = DateTime.Now;
        }

        public void UpdateUserState()
        {
            UserState.UpdateUserState(this);
            Console.WriteLine($"User's state is now: {UserState.GetType().Name}");

            DateTime currentDate = DateTime.Now;
            if (currentDate.Month != ResetWithdrawal.Month || currentDate.Year != ResetWithdrawal.Year)
            {
                WithdrawalsThisMonth = 0; 
                ResetWithdrawal = currentDate; 
            }
        }
    }
}

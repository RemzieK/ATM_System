using Bank.Accounts;
using Bank.States;
using System;


namespace Bank.Users
{
    public interface IUser
    {
        public string Id { get; }
        public string Name { get; }
        Account Account { get; }
        IUserState UserState { get; set; }
        int WithdrawalsThisMonth { get; set; }

        void UpdateUserState();
    }
}

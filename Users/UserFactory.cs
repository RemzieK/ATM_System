using Bank.Accounts;
using Bank.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Users
{
    public class UserFactory
    {
        public IUser CreateUser(string name, Account account,IUserState initialState)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            return new User(name, account, initialState); ;
        }
    }
}

using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.States
{
    public class StandardUserState : IUserState
    {
        public void UpdateUserState(User user)
        {
            if (user.WithdrawalsThisMonth > 10)
            {
                user.UserState = new PremiumUserState();
            }
            else
            {
                user.UserState = new StandardUserState();
            }
        }
    }
}

using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.States
{
    public class PremiumUserState : IUserState
    {
        public void UpdateUserState(User user)
        {
            if (user.WithdrawalsThisMonth > 10 && user.WithdrawalsThisMonth <= 20)
            {
                user.UserState = new PremiumUserState();
            }
            else if (user.WithdrawalsThisMonth > 20)
            {
                user.UserState = new PlatinumUserState();
            }
            else
            {
                user.UserState = new StandardUserState();
            }
        }
    }
}



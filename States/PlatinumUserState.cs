using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.States
{
    public class PlatinumUserState : IUserState
    {
        public void UpdateUserState(User user)
        {
            if (user.WithdrawalsThisMonth > 20)
            {
                user.UserState = new PlatinumUserState();
            }
        }
    }
}

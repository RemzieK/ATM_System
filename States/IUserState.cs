using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.States
{
    public interface IUserState
    {
        void UpdateUserState(User user);
    }
}

using Bank.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Observe
{
    public interface IObserver
    {
        void Update(ICommand command);
    }
}

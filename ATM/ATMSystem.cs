using Bank.Accounts;
using Bank.Bank;
using Bank.Commands;
using Bank.Fees;
using Bank.Observe;
using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ATM
{
    public class ATMSystem : IObservable
    {
        private List<IObserver> _observers;
        public ATMSystem()
        {
            _observers = new List<IObserver>();
        }
        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }
        public void RemoveObserver(IObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }
        public void NotifyObservers(ICommand command)
        {
            foreach (var observer in _observers)
            {
                observer.Update(command);
            }
        }
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            NotifyObservers(command);
        }
      
    }
}

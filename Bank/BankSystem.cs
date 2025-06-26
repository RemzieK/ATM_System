using Bank.Accounts;
using Bank.Commands;
using Bank.Observe;
using Bank.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Bank
{
    public class BankSystem : IObserver
    {
        private static BankSystem _instance;
        private readonly List<string> _transactionLog;
        private BankSystem()
        {
            _transactionLog = new List<string>();
        }
        public static BankSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BankSystem();
                }
                return _instance;
            }
        }
        public void Update(ICommand command)
        {
            string logEntry = $"Command executed: {command.GetType().Name} at {DateTime.Now}";
            _transactionLog.Add(logEntry);
            Console.WriteLine($"Bank updated: {logEntry}");
        }
        public void ShowTransactionLog()
        {
            Console.WriteLine("Transaction Log:");
            foreach (var transaction in _transactionLog)
            {
                Console.WriteLine(transaction);
            }
        }
       
    }
}


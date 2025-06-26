using Bank.Accounts;
using Bank.ATM;
using Bank.Commands;
using Bank.States;
using Bank.Users;
using Bank.Bank;


class Program
{
    static void Main(string[] args)
    {

        ATMSystem atm = new ATMSystem();
        atm.RegisterObserver(BankSystem.Instance);

        UserFactory userFactory = new UserFactory();

        IUser user1 =userFactory.CreateUser("User1", new Account(), new StandardUserState());
        IUser user2 = userFactory.CreateUser("User2", new Account(), new StandardUserState());

        while (true)
        {
            Console.WriteLine("Please select an operation:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Show Transaction Log");
            Console.WriteLine("6. Exit");

            int operation = Convert.ToInt32(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    Console.WriteLine("Enter amount to deposit:");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    ICommand depositCommand = new DepositCommand(atm, user1.Account, depositAmount);
                    atm.ExecuteCommand(depositCommand);
                    break;
                case 2:
                    Console.WriteLine("Enter amount to withdraw:");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    ICommand withdrawCommand = new WithdrawCommand(user1.Account, withdrawAmount);
                    atm.ExecuteCommand(withdrawCommand);
                    user1.WithdrawalsThisMonth++;
                    user1.UpdateUserState();
                    break;
                case 3:
                    Console.WriteLine("Enter amount to transfer:");
                    decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
                    ICommand transferCommand = new TransferCommand(user1.Account, user2.Account, transferAmount,user1.Name,user2.Name);
                    atm.ExecuteCommand(transferCommand);
                    user1.WithdrawalsThisMonth++;
                    user1.UpdateUserState();
                    break;
                case 4:
                    ICommand checkBalanceCommand = new CheckBalanceCommand(user1.Account);
                    atm.ExecuteCommand(checkBalanceCommand);
                    break;
                case 5:
                    BankSystem.Instance.ShowTransactionLog();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }
        }
    }
}

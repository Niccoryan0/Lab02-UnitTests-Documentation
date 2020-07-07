using System;

namespace Lab02_UnitTests
{
    class Program
    {
        public static decimal Balance = 2000;

        static void Main(string[] args)
        {
            UserInterface();
        }


        static void UserInterface()
        {
            Console.WriteLine("Hello and welcome to N&R Banking Inc.!");
            int choice;
            do
            {
                Console.WriteLine("How can we help ya today?");
                Console.WriteLine(@"1. Withdraw
                2. Deposit
                3. View Balance
                4. Exit");
                choice = int.Parse(Console.ReadLine());
                string repeat = "y";
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Amount to withdraw: ");
                        decimal withdrawAmount = Decimal.Parse(Console.ReadLine());
                        decimal newBal = Withdraw(withdrawAmount);
                        if (newBal > 0)
                        {
                            Console.WriteLine($"Withdraw of {withdrawAmount} successful! New balance: {newBal} ")
                        } else
                        {
                            Console.WriteLine($"There was an issue with your withdrawl, cannot withdraw amount : {withdrawAmount} from current balance: {Balance}")
                        }
                        break;
                    case 2:
                        Console.WriteLine("Amount to deposit: ");
                        decimal depositAmount = Decimal.Parse(Console.ReadLine());
                        // Deposit(depositAmount);
                        break;
                    case 3:
                        // ViewBalance();
                        break;
                    case 4:
                        repeat = "n";
                        break;
                }
                if(repeat == "y")
                {
                    Console.WriteLine("Choose another option? y/n");
                    repeat = Console.ReadLine();
                }
                if (repeat == "n")
                {
                    break;
                }
            } while (choice != 4);
        }

        public static decimal Withdraw(decimal amount)
        {
            if (amount > 0 && amount < Balance)
            {
                return Balance -= amount;
            } else
            {
                return -1;
            }
        }
    }
}

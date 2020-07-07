using System;

namespace Lab02_UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface();
        }

        static void UserInterface()
        {
            Console.WriteLine("Hello and welcome to N&R Banking Inc.!");
            Console.WriteLine("How can we help ya today?");
            int choice;
            do
            {
                string options = @"1. Withdraw
                2. Deposit
                3. View Balance
                4. Exit";
                Console.WriteLine(options);
                choice = int.Parse(Console.ReadLine());
                string repeat = "y";
                switch (choice)
                {
                    case 1:
                        // Withdraw();
                        break;
                    case 2:
                        // Deposit();
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
    }
}

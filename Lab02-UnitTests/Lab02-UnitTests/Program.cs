﻿using System;

namespace Lab02_UnitTests
{
    public class Program
    {
        public static decimal Balance = 2000;

        /// <summary>
        /// Runs the user interface function to display console application.
        /// </summary>
        static void Main(string[] args)
        {
            UserInterface();
        }

        /// <summary>
        /// Runs the user interface for the console application, takes in user input and calls functions for what the user wants to do.
        /// </summary>
        public static void UserInterface()
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
                        decimal newBalWith = Withdraw(withdrawAmount);
                        if (newBalWith >= 0)
                        {
                            Console.WriteLine($"Withdraw of {withdrawAmount} successful! New balance: {newBalWith} ");
                        } 
                        else
                        {
                            Console.WriteLine($"There was an issue with your withdrawl, cannot withdraw amount : {withdrawAmount} from current balance: {Balance}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Amount to deposit: ");
                        decimal depositAmount = Decimal.Parse(Console.ReadLine());
                        decimal newBalDep = Deposit(depositAmount);
                        if (newBalDep > 0)
                        {
                            Console.WriteLine($"Deposit of {depositAmount} successful! New balance: {newBalDep} ");
                        }
                        else
                        {
                            Console.WriteLine($"There was an issue with your deposit, cannot deposit amount : {depositAmount}");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Your current balance is : {ViewBalance()}");
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

        /// <summary>
        /// Handles withdrawing funds.
        /// </summary>
        /// <param name="amount">Amount to be withdrawn</param>
        /// <returns>Returns the new balance if the amount is valid and -1 if not</returns>
        public static decimal Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                return Balance -= amount;
            } else
            {
                return -1;
            }
        }

        /// <summary>
        /// Handles depositing funds.
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        /// <returns>Returns the new balance if the amount is valid and -1 if not</returns>
        public static decimal Deposit(decimal amount)
        {
            if (amount > 0)
            {
                return Balance += amount;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Shows the user their balance.
        /// </summary>
        /// <returns>Current balance</returns>
        public static decimal ViewBalance()
        {
            return Balance;
        }
    }
}

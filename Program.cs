﻿using System;

namespace MySuperBank
{
    internal class SuperBank
    {   //Main method
        //main method is calling on the constructor of BankAccount to create a new object
        private static void Main(string[] args)
        {   //Creating object
            var account = new BankAccount("Kendra", 10000);
            // above provides value for the arguments in constructor of BankAccount
            Console.WriteLine($"Account {account.Number} was created for a {account.Owner} with {account.Balance}.");
            // below shows values being added to the properties
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
            //below gets the account history from the function
            Console.WriteLine(account.GetAccountHistory());
            // Test that the initial balances must be positive.

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }
            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
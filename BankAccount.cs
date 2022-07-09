//C# program to illustrate the
//Initialization of an object
using System;
using System.Collections.Generic;

namespace MySuperBank
{   //Class Declaration that defines the class/type
    //anything inside the Declaration defines the state and behavior of the class
    public class BankAccount

    { //Instance Variable? Combined with //Property 1
        public string Number { get; }

        //Instance Variable? Combined with //Property 2
        public string Owner { get; set; }

        //Instance Variable? Combined with //Property 3
        //in this property we are computing balance when another programmer
        //ask for value. this enumerates/establishes the number of all transactions
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                    //this is like balance = balance + item.Amount
                }

                return balance;
            }
        }

        //member declaration this is a data member
        //it is private so it can only be accessed by code inside BankClass
        //its static so it is shared by all objects of the BankAccount objects
        private static int accountNumberSeed = 1234567890;

        //Making BankAccount Object and defining constructor that assigns those values
        //Constructor is a member that has the same name as the class. And it used to initialize objects of that class/type
        //Called when you create an object using new
        //the this. is optional

        public BankAccount(string name, decimal initialBalance) //inside is the variable and their type name
        {    //owner is the object, state/attribute is the this.Owner/this.Number /the behavior is how it responds
            this.Owner = name; // arguments
            //this.Balance = initialBalance;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            // we call the method from our constructor
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        //Below is a declaration constructor, similar to component being imported
        private List<Transaction> allTransactions = new List<Transaction>();

        //Method 1
        //These methods will enforce our rules and introduce the concept of
        //exceptions
        // the throws sate throws an exception which will have a catch block
        //later in the code
        // void is to declare a method that does not return a value
        //instead it will
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        //This example shows an important aspect of properties.You're now computing the balance
        //    when another programmer asks for the value. Your computation enumerates all
        //    transactions, and provides the sum as the current balance.
        //These rules introduce the concept of exceptions
        //Here the type of exception and the message associated with it describe the error.
        //Method 2
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        //this is to get all account history
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();
            //here we use the string builder to format a string that contains
            //a line for each transaction and we one \t which inserts a tab "indent"
            //to format the output
            decimal balance = 0;
            // report is a local variable we use to help us use AppendLine which appends
            // the copy of specified string into the default line
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            // below we return the value of report and use the system function to a string
            return report.ToString();
        }
    }
}
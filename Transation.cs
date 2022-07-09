using System;
using System.Text;

namespace MySuperBank
{   //Type transaction
    public class Transaction
    {   //properties
        public decimal Amount { get; }

        public string Notes { get; }

        public DateTime Date { get; }

        //Constructor making the transaction object
        //we use this in BankAccounts by using List<Transactions>
        //sort of like the component being exported in React
        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
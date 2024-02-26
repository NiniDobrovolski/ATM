using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Transaction
    {
        public string TransactionType { get; }
        public int AmountOfMoney { get; }
        public DateTime Date { get; }
        public Transaction(string type, int amount, DateTime date)
        {
            TransactionType = type;
            AmountOfMoney = amount;
            Date = date;
        }
    }
}

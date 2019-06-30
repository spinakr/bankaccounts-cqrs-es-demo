using System;

namespace Domain.Model
{
    public class Transfer
    {
        public Transfer(string toAccount, string fromAccount, double amount, DateTime date)
        {
            FromAccountId = fromAccount;
            ToAccountId = toAccount;
            Amount = amount;
            Date = date;
        }

        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
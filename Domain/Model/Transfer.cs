using System;

namespace Domain.Model
{
    public class Transfer
    {
        public Transfer(Guid toAccount, Guid fromAccount, double amount, DateTime date)
        {
            FromAccountId = fromAccount;
            ToAccountId = toAccount;
            Amount = amount;
            Date = date;
        }

        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
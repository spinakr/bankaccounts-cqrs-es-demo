using System;

namespace Domain.Model
{
    public class Transfer
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
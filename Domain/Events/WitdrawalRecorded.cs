using System;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using Domain.Model;

namespace BankAccounts.Domain.Events
{
    public class WitdrawalRecorded : Event
    {
        public WitdrawalRecorded(Guid toAccount, Guid fromAccount, double amount, DateTime date)
        {
            StreamName = fromAccount.ToString();
            Transfer = new Transfer(fromAccount, toAccount, amount, date);
        }
        public Transfer Transfer { get; set; }
    }
}
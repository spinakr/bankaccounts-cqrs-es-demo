using System;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using Domain.Model;

namespace BankAccounts.Domain.Events
{
    public class DepositRecorded : Event
    {
        public DepositRecorded(Guid toAccount, Guid fromAccount, double amount, DateTime date)
        {
            StreamName = toAccount.ToString();
            Transfer = new Transfer(fromAccount, toAccount, amount, date);
        }

        public Transfer Transfer { get; set; }
    }
}
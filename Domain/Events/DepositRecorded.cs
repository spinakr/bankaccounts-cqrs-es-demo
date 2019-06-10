using System;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using CQRS;
using Domain.Model;

namespace BankAccounts.Domain.Events
{
    public class DepositRecorded : IEvent
    {
        public DepositRecorded(Guid toAccount, Guid fromAccount, double amount, DateTime date)
        {
            Transfer = new Transfer(fromAccount, toAccount, amount, date);
        }

        public Transfer Transfer { get; set; }
    }
}
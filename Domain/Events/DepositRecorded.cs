using System;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using CQRS;
using Domain.Model;

namespace BankAccounts.Domain.Events
{
    public class DepositRecorded : IEvent
    {
        public DepositRecorded(Guid fromCustomerId, Guid toCustomerId, Guid toAccount, Guid fromAccount, double amount, DateTime date)
        {
            FromCustomerId = fromCustomerId;
            ToCustomerId = toCustomerId;
            Transfer = new Transfer(fromAccount, toAccount, amount, date);
        }

        public Guid FromCustomerId { get; set; }
        public Guid ToCustomerId { get; set; }
        public Transfer Transfer { get; set; }
    }
}
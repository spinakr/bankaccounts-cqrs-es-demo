using System;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using CQRS;
using Domain.Model;

namespace BankAccounts.Domain.Events
{
    public class WitdrawalRecorded : IEvent
    {
        public WitdrawalRecorded(Guid fromCustomerId, Guid toCustomerId, string toAccount, string fromAccount, double amount, DateTime date)
        {
            FromCustomerId = fromCustomerId;
            ToCustomerId = toCustomerId;
            Transfer = new Transfer(toAccount, fromAccount, amount, date);
        }

        public Guid FromCustomerId { get; set; }
        public Guid ToCustomerId { get; set; }
        public Transfer Transfer { get; set; }
    }
}
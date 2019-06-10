using System;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using CQRS;

namespace BankAccounts.Domain.Events
{
    public class AccountCreated : IEvent
    {

        public AccountCreated(Guid accountId, string accountName, Guid customerId)
        {
            this.CustomerId = customerId;
            this.AccountId = accountId;
            this.AccountName = accountName;
        }

        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
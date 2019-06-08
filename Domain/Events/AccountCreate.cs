using System;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;

namespace BankAccounts.Domain.Events
{
    public class AccountCreated : Event
    {

        public AccountCreated(Guid accountId, string accountName, Guid customerId)
        {
            this.StreamName = accountId.ToString();
            this.CustomerId = customerId;
            this.AccountId = accountId;
            this.AccountName = accountName;
        }

        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
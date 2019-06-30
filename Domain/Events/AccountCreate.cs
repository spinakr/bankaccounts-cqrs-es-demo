using System;
using CQRS;

namespace BankAccounts.Domain.Events
{
    public class AccountCreated : IEvent
    {

        public AccountCreated(string accountId, string accountName, Guid customerId)
        {
            CustomerId = customerId;
            AccountId = accountId;
            AccountName = accountName;
        }

        public Guid CustomerId { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
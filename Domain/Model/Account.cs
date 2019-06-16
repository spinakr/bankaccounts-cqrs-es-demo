using System;
using System.Collections.Generic;
using BankAccounts.Domain.Events;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using CQRS;

namespace BankAccounts.Domain.Model
{
    public class Account : EventSourcedAggregate
    {
        public Account() { }

        public Account(IEnumerable<IEvent> events) : base(events) { }

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public static Account CreateNew(string name, Guid customerId)
        {
            var @event = new AccountCreated(Guid.NewGuid(), name, customerId);
            var newAccount = new Account();
            newAccount.Append(@event);
            return newAccount;
        }

        public void DepositAmount(Guid fromCustomerId, Guid fromAccount, double amount)
        {
            var @event = new DepositRecorded(fromCustomerId, CustomerId, Id, fromAccount, amount, DateTime.Now);
            Append(@event);
        }

        public void WithdrawAmount(Guid toCustomerId, Guid toAccount, double amount)
        {
            var @event = new WitdrawalRecorded(CustomerId, toCustomerId, toAccount, Id, amount, DateTime.Now);
            Append(@event);
        }

        public void When(AccountCreated @event)
        {
            Id = @event.AccountId;
            CustomerId = @event.CustomerId;
            Name = @event.AccountName;
            Balance = 0;
        }

        public void When(DepositRecorded e)
        {
            Balance += e.Transfer.Amount;
        }

        public void When(WitdrawalRecorded e)
        {
            Balance -= e.Transfer.Amount;
        }

    }
}

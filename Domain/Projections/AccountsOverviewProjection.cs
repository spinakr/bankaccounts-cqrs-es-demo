using System;
using System.Linq;
using BankAccounts.CQRS.Projections;
using BankAccounts.Domain.Events;
using BankAccounts.Domain.Queries;
using CQRS;

namespace Domain.Projections
{
    public class AccountsOverviewProjection : IEventHandler<AccountCreated>
    {
        private IProjectionStore<Guid, AccountsOverview> _projectionStore;

        public AccountsOverviewProjection(IProjectionStore<Guid, AccountsOverview> projectionStore)
        {
            _projectionStore = projectionStore;
        }

        public void Handle(AccountCreated @event)
        {
            var projection = _projectionStore.GetProjection(@event.CustomerId);
            projection.CustomerId = @event.CustomerId;
            projection.Accounts.Add(new AccountOverview
            {
                AccountId = @event.AccountId.ToString(),
                AccountName = @event.AccountName,
                Balance = 0
            });
            _projectionStore.Save(@event.CustomerId, projection);
        }
    }
}
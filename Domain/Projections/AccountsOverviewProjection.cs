using System;
using System.Linq;
using BankAccounts.CQRS.Projections;
using BankAccounts.Domain.Events;
using BankAccounts.Domain.Queries;
using CQRS;

namespace Domain.Projections
{
    public class AccountsOverviewProjection : IEventHandler<AccountCreated>, IEventHandler<DepositRecorded>, IEventHandler<WitdrawalRecorded>
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

        public void Handle(WitdrawalRecorded @event)
        {
            var projection = _projectionStore.GetProjection(@event.FromCustomerId);
            projection.Accounts.Single(a => a.AccountId == @event.Transfer.FromAccountId.ToString()).Balance -= @event.Transfer.Amount;
            _projectionStore.Save(@event.FromCustomerId, projection);
        }

        public void Handle(DepositRecorded @event)
        {
            var projection = _projectionStore.GetProjection(@event.ToCustomerId);
            projection.Accounts.Single(a => a.AccountId == @event.Transfer.ToAccountId.ToString()).Balance += @event.Transfer.Amount;
            _projectionStore.Save(@event.ToCustomerId, projection);
        }
    }
}
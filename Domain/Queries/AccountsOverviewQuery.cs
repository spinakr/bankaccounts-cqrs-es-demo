using System;
using System.Collections.Generic;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;
using BankAccounts.CQRS.Projections;

namespace BankAccounts.Domain.Queries
{
    public class AccountsOverviewQuery : IQuery<AccountsOverview>
    {
        public string CustomerId { get; set; }

        public AccountsOverviewQuery(string customerId)
        {
            CustomerId = customerId;
        }
    }

    public class AccountsOverviewQueryHandler : IQueryHandler<AccountsOverviewQuery, AccountsOverview>
    {
        private IProjectionStore<Guid, AccountsOverview> _projectionStore;

        public AccountsOverviewQueryHandler(IProjectionStore<Guid, AccountsOverview> projectionStore)
        {
            _projectionStore = projectionStore;
        }

        private IEventStore _eventStore { get; }

        public AccountsOverview Handle(AccountsOverviewQuery query)
        {
            var projection = _projectionStore.GetProjection(Guid.Parse(query.CustomerId));
            return projection;
        }
    }
}
using System.Collections.Generic;
using BankAccounts.Messaging;

namespace BankAccounts.Domain.Queries
{
    public class AccountsOverviewQuery : IQuery<IEnumerable<AccountOverview>>
    {
        public string CustomerId { get; set; }

        public AccountsOverviewQuery(string customerId)
        {
            CustomerId = customerId;
        }
    }

    public class AccountsOverviewQueryHandler : IQueryHandler<AccountsOverviewQuery, IEnumerable<AccountOverview>>
    {
        public AccountsOverviewQueryHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        private IEventStore _eventStore { get; }

        public IEnumerable<AccountOverview> Handle(AccountsOverviewQuery query)
        {
            return new List<AccountOverview>
            {

            };
        }
    }
}
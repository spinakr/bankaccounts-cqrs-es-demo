using System;
using System.Collections.Generic;
using BankAccounts.Domain.Model;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;

namespace BankAccounts.Domain.Queries
{

    public class AccountQuery : IQuery<AccountOverview>
    {
        public Guid AccountId { get; set; }

        public AccountQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }

    public class AccountQueryHandler : IQueryHandler<AccountQuery, AccountOverview>
    {
        public AccountQueryHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        private IEventStore _eventStore { get; }

        public AccountOverview Handle(AccountQuery query)
        {
            var eventStream = _eventStore.LoadEventStream(query.AccountId.ToString());
            var account = new Account(eventStream.Events);

            return new AccountOverview
            {
                AccountName = account.Name,
                Balance = account.Balance,
                AccountId = account.Id.ToString()
            };
        }
    }
}
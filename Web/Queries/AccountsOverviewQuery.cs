using System;
using System.Collections.Generic;
using BankAccounts.Utils;

namespace BankAccounts.Queries
{
    public class AccountOverview
    {
    }

    public class AccountsOverviewQuery : IQuery<IEnumerable<AccountOverview>>
    {
        public AccountsOverviewQuery(string customerId) { }
    }

    public class AccountsOverviewQueryHandler : IQueryHandler<AccountsOverviewQuery, IEnumerable<AccountOverview>>
    {
        public AccountsOverviewQueryHandler()
        {
        }

        public IEnumerable<AccountOverview> Handle(AccountsOverviewQuery query)
        {
            return new List<AccountOverview>();
        }
    }
}
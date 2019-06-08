using System;
using System.Collections.Generic;

namespace BankAccounts.Domain.Queries
{
    public class AccountsOverview
    {
        public Guid CustomerId { get; set; }
        public List<AccountOverview> Accounts { get; set; } = new List<AccountOverview>();
    }
}
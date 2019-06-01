using System;
using System.Collections.Generic;
using BankAccounts.Domain.Queries;
using BankAccounts.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Controllers
{
    [Route("api/customers/")]
    public class AccountsController : Controller
    {
        private readonly IMessaging _messaging;

        public AccountsController(IMessaging messaging)
        {
            _messaging = messaging;

        }

        [HttpGet("{customerId}/accounts/{accountId}")]
        public AccountOverview AccountOverview(Guid customerId, Guid accountId)
        {
            return _messaging.Dispatch(new AccountQuery(accountId));
        }

        [HttpGet("{customerId}/accounts")]
        public IEnumerable<AccountOverview> CustomerAccountsOverview(string customerId)
        {
            return _messaging.Dispatch(new AccountsOverviewQuery(customerId));

        }

        [HttpPost("{customerId}/accounts")]
        public IActionResult CreateAccount(Guid customerId, [FromBody]dynamic req)
        {
            var result = _messaging.Dispatch(new CreateAccountCommand(customerId, (string)req.name));

            return Ok(result.AggregateId);
        }
    }
}

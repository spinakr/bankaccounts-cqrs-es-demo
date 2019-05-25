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

        [HttpGet("{customerId}/accounts")]
        public IEnumerable<AccountOverview> AccountsOverview(string customerId)
        {
            return _messaging.Dispatch(new AccountsOverviewQuery(customerId));

        }

        [HttpPost]
        public IActionResult CreateAccount(Guid customerId, string name)
        {
            return Ok();
        }
    }
}

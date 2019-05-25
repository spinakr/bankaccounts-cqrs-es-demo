using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Queries;
using BankAccounts.Utils;
using Microsoft.AspNetCore.Mvc;

namespace bankaccounts.Controllers
{
    [Route("api/customers/")]
    public class AccountsController : Controller
    {
        private IMessaging _messaging;

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

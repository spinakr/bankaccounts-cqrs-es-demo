using System;
using System.Collections.Generic;
using BankAccounts.CQRS;
using BankAccounts.Domain.Queries;
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
        public AccountOverview AccountOverview(Guid customerId, string accountId)
        {
            return _messaging.Dispatch(new AccountQuery(accountId));
        }

        [HttpGet("{customerId}/accounts")]
        public AccountsOverview CustomerAccountsOverview(string customerId)
        {
            return _messaging.Dispatch(new AccountsOverviewQuery(customerId));

        }

        [HttpPost("{customerId}/accounts")]
        public IActionResult CreateAccount(Guid customerId, [FromBody]dynamic req)
        {
            var result = _messaging.Dispatch(new CreateAccountCommand(customerId, (string)req.name));

            return Ok(((Result<Guid>)result).Value);
        }

        [HttpPost("{customerId}/accounts/transfer")]
        public IActionResult TransferTo(Guid customerId, [FromBody]dynamic req)
        {
            var result = _messaging.Dispatch(new MakeTransferCommand((string)req.FromAccountId, (string)req.ToAccountId, (double)req.Amount));

            return Ok();
        }
    }
}

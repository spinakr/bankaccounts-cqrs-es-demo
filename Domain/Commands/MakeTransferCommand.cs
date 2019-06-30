using System;
using BankAccounts.Domain.Model;
using BankAccounts.CQRS;
using BankAccounts.CQRS.EventStore;

namespace BankAccounts.Domain.Queries
{
    public class MakeTransferCommand : ICommand
    {
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public double Amount { get; set; }

        public MakeTransferCommand(string fromAccount, string toAccount, double amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = amount;
        }
    }

    public class MakeTransferCommandHandler : ICommandHandler<MakeTransferCommand>
    {
        public MakeTransferCommandHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        private IEventStore _eventStore { get; }

        public Result Handle(MakeTransferCommand cmd)
        {
            var fromAccountStream = _eventStore.LoadEventStream(cmd.FromAccount);
            var fromAccount = new Account(fromAccountStream.Events);
            var toAccountStream = _eventStore.LoadEventStream(cmd.ToAccount);
            var toAccount = new Account(toAccountStream.Events);

            if (fromAccount.CustomerId != Guid.Empty)
            {
                fromAccount.WithdrawAmount(toAccount.CustomerId, cmd.ToAccount, cmd.Amount);
                _eventStore.AppendToStream(fromAccount.Id, fromAccount.PendingEvents, fromAccountStream.Version);
            }

            if (toAccount.CustomerId != Guid.Empty)
            {
                toAccount.DepositAmount(fromAccount.CustomerId, cmd.FromAccount, cmd.Amount);
                _eventStore.AppendToStream(toAccount.Id, toAccount.PendingEvents, toAccountStream.Version);
            }

            return Result.Complete();
        }
    }
}
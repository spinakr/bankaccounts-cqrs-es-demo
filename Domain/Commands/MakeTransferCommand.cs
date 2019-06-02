using System;
using BankAccounts.Domain.Model;
using BankAccounts.Messaging;

namespace BankAccounts.Domain.Queries
{
    public class MakeTransferCommand : ICommand
    {
        public Guid FromAccount { get; set; }
        public Guid ToAccount { get; set; }
        public double Amount { get; set; }

        public MakeTransferCommand(Guid fromAccount, Guid toAccount, double amount)
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
            var fromAccount = new Account(_eventStore.LoadEventStream(cmd.FromAccount.ToString()));
            var toAccount = new Account(_eventStore.LoadEventStream(cmd.ToAccount.ToString()));

            fromAccount.WithdrawAmount(toAccount.Id, cmd.Amount);
            toAccount.DepositAmount(fromAccount.Id, cmd.Amount);

            _eventStore.AppendToStream(fromAccount.Id.ToString(), fromAccount.PendingEvents);
            _eventStore.AppendToStream(toAccount.Id.ToString(), toAccount.PendingEvents);

            return Result.Success();
        }
    }
}
using System;
using BankAccounts.Domain.Model;
using BankAccounts.Messaging;

namespace BankAccounts.Domain.Queries
{
    public class CreateAccountCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }

        public CreateAccountCommand(Guid customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }
    }

    public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand>
    {
        public CreateAccountCommandHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        private IEventStore _eventStore { get; }

        public Result Handle(CreateAccountCommand cmd)
        {
            var newAccount = Account.CreateNew(cmd.Name, cmd.CustomerId);
            _eventStore.AppendToStream(newAccount.Id.ToString(), newAccount.PendingEvents);
            return Result.Success(newAccount.Id);
        }
    }
}
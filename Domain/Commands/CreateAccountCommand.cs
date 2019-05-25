using System;
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
        public CreateAccountCommandHandler()
        {
        }

        public Result Handle(CreateAccountCommand cmd)
        {
            return Result.Success;
        }
    }
}
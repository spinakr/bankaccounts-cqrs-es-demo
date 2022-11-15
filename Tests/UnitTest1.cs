using BankAccounts.Domain.Events;
using BankAccounts.Domain.Model;
using FluentAssertions;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateAccount()
    {
        var otherAccount = AccountId.GenerateNewAccountId();

        var newAccount = Account.CreateNew("Brukskonto", Guid.NewGuid());
        newAccount.DepositAmount(otherAccount, 1000);
        newAccount.WithdrawAmount(otherAccount, 500);

        newAccount.PendingEvents.Count().Should().Be(3);
        newAccount.PendingEvents.First().Should().BeOfType<AccountWasOpened>();
        newAccount.Balance.Should().Be(500);





    }
}
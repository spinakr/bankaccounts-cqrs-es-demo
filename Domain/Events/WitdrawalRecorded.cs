using System;
using BankAccounts.Messaging;
using Domain.Model;

namespace BankAccounts.Domain.Events
{
    public class WitdrawalRecorded : Event
    {
        public Transfer Transfer { get; set; }
    }
}
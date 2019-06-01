using System;
using BankAccounts.Messaging;
using Domain.Model;

namespace BankAccounts.Domain.Events
{
    public class DepositRecorded : Event
    {
        public Transfer Transfer { get; set; }
    }
}
using System;
using CQRS;

namespace BankAccounts.CQRS.EventStore
{
    public class Event : IEvent
    {
        public string StreamName { get; set; }
    }
}
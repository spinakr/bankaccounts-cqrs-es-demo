using System;
using System.Collections.Generic;

namespace BankAccounts.CQRS.EventStore
{
    public interface IEventStore
    {
        EventStream LoadEventStream(string streamName);
        void AppendToStream(string streamName, ICollection<Event> events, int originalVersion);
    }
}
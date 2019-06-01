using System;
using System.Collections.Generic;

namespace BankAccounts.Messaging
{
    public interface IEventStore
    {
        IEnumerable<Event> LoadEventStream(string streamName);
        void AppendToStream(string streamName, ICollection<Event> events);
    }
}
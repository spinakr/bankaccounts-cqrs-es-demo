using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccounts.Messaging
{
    public class InMemoryEventStore : IEventStore
    {
        private static List<Event> _events = new List<Event>();

        public void AppendToStream(string streamName, ICollection<Event> events)
        {
            _events.AddRange(events);
        }

        public IEnumerable<Event> LoadEventStream(string streamName)
        {
            return _events.Where(e => e.StreamName == streamName);
        }
    }
}
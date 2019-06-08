using System.Collections.Generic;

namespace BankAccounts.CQRS.EventStore
{
    public class EventStream
    {
        public int Version { get; set; }
        public List<Event> Events = new List<Event>();
    }
}
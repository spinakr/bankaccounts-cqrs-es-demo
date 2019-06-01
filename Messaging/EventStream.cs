using System.Collections.Generic;

namespace BankAccounts.Messaging
{
    public class EventStream
    {
        public int Version { get; set; }
        public IList<Event> Events = new List<Event>();
    }
}
using System;
using System.Collections.Generic;

namespace BankAccounts.Messaging
{
    public abstract class EventSourcedAggregate
    {
        public Guid Id { get; set; }

        protected EventSourcedAggregate(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                Mutate(@event);
            }
        }

        public List<Event> PendingEvents { get; private set; }

        protected EventSourcedAggregate()
        {
            PendingEvents = new List<Event>();
        }

        protected void Append(Event @event)
        {
            PendingEvents.Add(@event);
            Mutate(@event);
        }

        private void Mutate(Event @event)
        {
            //Exexute correct method on the aggregate
            ((dynamic)this).When((dynamic)@event);
        }
    }
}
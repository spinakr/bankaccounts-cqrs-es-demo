using System;
using System.Collections.Generic;

namespace BankAccounts.Utils
{
    public abstract class EventSourcedAggregate
    {
        public string Id { get; set; }

        public Queue<IEvent> PendingEvents { get; private set; }

        protected EventSourcedAggregate()
        {
            PendingEvents = new Queue<IEvent>();
        }

        protected void Append(IEvent @event)
        {
            PendingEvents.Enqueue(@event);
        }
    }
}
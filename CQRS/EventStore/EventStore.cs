using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace BankAccounts.CQRS.EventStore
{
    public class EventStore : IEventStore
    {
        public EventStore(IAppendOnlyStore appendOnlyStore)
        {
            _appendOnlyStore = appendOnlyStore;
        }

        private IAppendOnlyStore _appendOnlyStore;

        public void AppendToStream(string streamName, ICollection<Event> events, int originalVersion)
        {
            var data = JsonConvert.SerializeObject(events, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            _appendOnlyStore.Append(streamName, data, originalVersion);
        }

        public EventStream LoadEventStream(string streamName)
        {
            var records = _appendOnlyStore.ReadRecords(streamName);
            var stream = new EventStream();
            foreach (var record in records)
            {
                stream.Events.AddRange(JsonConvert.DeserializeObject<ICollection<Event>>(record.JsonData, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));
                stream.Version = record.Version;
            }
            return stream;
        }
    }
}
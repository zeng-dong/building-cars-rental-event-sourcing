using Newtonsoft.Json;
using System;

namespace CarsIsland.EventBus.Events
{
    public class IntegrationEvent
    {
        [JsonConstructor]
        public IntegrationEvent()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonProperty]
        public Guid ID { get; private set; }
        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}

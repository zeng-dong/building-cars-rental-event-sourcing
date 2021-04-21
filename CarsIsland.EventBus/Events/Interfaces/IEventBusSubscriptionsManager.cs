using System;

namespace CarsIsland.EventBus.Events.Interfaces
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }

        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>()
           where T : IntegrationEvent
           where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>()
           where TH : IIntegrationEventHandler<T>
           where T : IntegrationEvent;


    }
}

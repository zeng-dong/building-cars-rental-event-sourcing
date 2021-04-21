using System.Threading.Tasks;

namespace CarsIsland.EventBus.Events.Interfaces
{
    public interface IEventBus
    {
        Task PublishAsync(IntegrationEvent evnt);

        Task SubscibeAsync<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        Task UnsubscribeAsync<T, TH>() where TH : IIntegrationEventHandler<T> where T : IntegrationEvent;

        Task SetupAsync();
    }
}

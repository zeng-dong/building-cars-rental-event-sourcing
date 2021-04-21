using System.Threading.Tasks;

namespace CarsIsland.EventBus.Events.Interfaces
{
    public interface IIntegrationEventHandler<in TIntergrationEvent> where TIntergrationEvent : IntegrationEvent
    {
        Task HandleAsync(TIntergrationEvent evnt);
    }
}

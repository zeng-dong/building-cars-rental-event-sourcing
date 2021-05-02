using CarsIsland.Catalog.Infrastructure.Services.Integration.Interfaces;
using CarsIsland.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace CarsIsland.Catalog.Infrastructure.Services.Integration
{
    public class CatalogIntegrationEventService : ICatalogIntegrationEventService
    {
        public Task AddAndSaveEventAsync(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }

        public Task PublishEventsThroughEventBusAsync(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}

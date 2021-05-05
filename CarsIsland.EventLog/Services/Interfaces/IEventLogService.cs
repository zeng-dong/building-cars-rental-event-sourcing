using CarsIsland.EventBus.Events;
using CarsIsland.EventLog.Entries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsIsland.EventLog.Services.Interfaces
{
    public interface IEventLogService
    {
        Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId);
        Task SaveEventAsync(IntegrationEvent @event, Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction);
        Task MarkEventAsPublishedAsync(Guid eventId);
        Task MarkEventAsInProgressAsync(Guid eventId);
        Task MarkEventAsFailedAsync(Guid eventId);
    }
}

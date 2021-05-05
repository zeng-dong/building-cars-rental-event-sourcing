using CarsIsland.EventBus.Events;
using CarsIsland.EventLog.Entries;
using CarsIsland.EventLog.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace CarsIsland.EventLog.Services
{
    public class EventLogService : IEventLogService
    {
        private readonly EventLogContext _integrationEventLogContext;
        private readonly DbConnection _dbConnection;
        private readonly List<Type> _eventTypes;

        public Task MarkEventAsFailedAsync(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public Task MarkEventAsInProgressAsync(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public Task MarkEventAsPublishedAsync(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}

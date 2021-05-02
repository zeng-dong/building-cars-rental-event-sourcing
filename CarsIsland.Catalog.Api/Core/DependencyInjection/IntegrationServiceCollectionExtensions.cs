using Microsoft.Extensions.DependencyInjection;

namespace CarsIsland.Catalog.Api.Core.DependencyInjection
{
    public static class IntegrationServiceCollectionExtensions
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services)
        {
            //var serviceProvider = services.BuildServiceProvider();
            //var azureServiceBusConfiguration = serviceProvider.GetRequiredService<IAzureServiceBusConfiguration>();
            //
            //services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            //                                                     
            //services.AddTransient<ICatalogIntegrationEventService, CatalogIntegrationEventService>();
            //
            //services.AddSingleton<IServiceBusConnectionManagementService>(sp =>
            //{
            //    var logger = sp.GetRequiredService<ILogger<ServiceBusConnectionManagementService>>();
            //    var serviceBusConnection = new ServiceBusConnectionStringBuilder(azureServiceBusConfiguration.ConnectionString);
            //    return new ServiceBusConnectionManagementService(logger, serviceBusConnection);
            //});
            //
            //services.AddSingleton<IEventBus, AzureServiceBusEventBus>(sp =>
            //{
            //    var serviceBusConnectionManagementService = sp.GetRequiredService<IServiceBusConnectionManagementService>();
            //    var logger = sp.GetRequiredService<ILogger<AzureServiceBusEventBus>>();
            //    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
            //
            //    var eventBus = new AzureServiceBusEventBus(serviceBusConnectionManagementService, eventBusSubcriptionsManager,
            //        serviceProvider, logger, azureServiceBusConfiguration.SubscriptionClientName);
            //    eventBus.SetupAsync().GetAwaiter().GetResult();
            //
            //    return eventBus;
            //});
            //
            //services.AddTransient<Func<DbConnection, IEventLogService>>(
            //        sp => (DbConnection connection) => new EventLogService(connection));

            return services;
        }
    }
}

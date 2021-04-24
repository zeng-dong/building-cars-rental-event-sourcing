using CarsIsland.EventBus.Events;
using CarsIsland.EventBus.Events.Interfaces;
using CarsIsland.EventBus.Services.Interfaces;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CarsIsland.EventBus.Services
{
    public class AzureServiceBusEventBus : IEventBus
    {
        private readonly SubscriptionClient _subscriptionClient;
        private readonly IEventBusSubscriptionsManager _subscriptionManager;
        private readonly IServiceBusConnectionManagementService _serviceBusConnectionManagementService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AzureServiceBusEventBus> _logger;

        public AzureServiceBusEventBus(IServiceBusConnectionManagementService serviceBusConnectionManagementService,
                        IEventBusSubscriptionsManager subscriptionManager,
                        IServiceProvider serviceProvider,
                        ILogger<AzureServiceBusEventBus> logger,
                        string subscriptionClientName)
        {
            _serviceBusConnectionManagementService = serviceBusConnectionManagementService;
            _subscriptionManager = subscriptionManager;
            _subscriptionClient = _subscriptionClient = new SubscriptionClient(_serviceBusConnectionManagementService.ServiceBusConnectionStringBuilder,
                subscriptionClientName);
            _serviceProvider = serviceProvider;
            _logger = logger;
        }


        public Task PublishAsync(IntegrationEvent evnt)
        {
            throw new NotImplementedException();
        }

        public async Task SetupAsync()
        {
            try
            {
                await RemoveDefaultRuleAsync();
                RegisterSubscriptionClientMessageHandler();
            }

            catch (MessagingEntityNotFoundException)
            {
                _logger.LogWarning("The messaging entity '{DefaultRuleName}' Could not be found.", RuleDescription.DefaultRuleName);
            }
        }

        public Task SubscibeAsync<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public Task UnsubscribeAsync<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        private void RegisterSubscriptionClientMessageHandler()
        {
            _subscriptionClient.RegisterMessageHandler(
                async (message, token) =>
                {
                    var eventName = message.Label;
                    var messageData = Encoding.UTF8.GetString(message.Body);

                    if (await ProcessEvent(eventName, messageData))
                    {
                        await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
                    }
                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = 10, AutoComplete = false });
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var ex = exceptionReceivedEventArgs.Exception;
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            _logger.LogError(ex, "ERROR handling message: '{ExceptionMessage}' - Context: '{ExceptionContext}'", ex.Message, context);

            return Task.CompletedTask;
        }
        private async Task<bool> ProcessEvent(string eventName, string message)
        {
            var processed = false;
            if (_subscriptionManager.HasSubscriptionsForEvent(eventName))
            {
                var subscriptions = _subscriptionManager.GetHandlersForEvent(eventName);
                foreach (var subscription in subscriptions)
                {
                    var handler = _serviceProvider.GetRequiredService(subscription.HandlerType);
                    if (handler == null) continue;

                    var eventType = _subscriptionManager.GetEventTypeByName(eventName);
                    var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                    var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("HandleAsync").Invoke(handler, new object[] { integrationEvent });
                    processed = true;
                }
            }

            return processed;
        }

        private async Task RemoveDefaultRuleAsync()
        {
            try
            {
                await _subscriptionClient.RemoveRuleAsync(RuleDescription.DefaultRuleName);
            }
            catch (MessagingEntityNotFoundException)
            {
                _logger.LogWarning("The messaging entity '{DefaultRuleName}' Could not be found.", RuleDescription.DefaultRuleName);
            }
        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using Core.Domain.Notifications;
using MassTransit;

namespace Core.Application.EventHandlers;


/// <summary>
/// Handles the event when a customer is created.
/// </summary>
public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedNotification>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger;
    private readonly IBusControl _bus;

    public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger, IBusControl bus)
    {
        _logger = logger;
        _bus = bus;
    }

    public async Task Handle(CustomerCreatedNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Yesss! I got the notification. \nNow I can publish to the brober using MassTRansit: Customer - {notification.customerId} " + $"- {notification.fullName} - {notification.email}");

            var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/Core.Domain.Notifications:CustomerCreatedNotification"));  //?bind=true&queue=dotnetgigs
            await endpoint.Send(notification);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling the CustomerCreatedNotification.");
        }
    }
}

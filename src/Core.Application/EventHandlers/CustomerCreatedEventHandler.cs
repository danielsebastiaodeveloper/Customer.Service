using MediatR;
using Microsoft.Extensions.Logging;
using Core.Domain.Notifications;

namespace Core.Application.EventHandlers;


/// <summary>
/// Handles the event when a customer is created.
/// </summary>
public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedNotification>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerCreatedEventHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles the CustomerCreatedNotification.
    /// </summary>
    /// <param name="notification">The CustomerCreatedNotification to handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task Handle(CustomerCreatedNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Yesss! I got the notification. \nNow I can publish to the brober using MassTRansit: Customer - {notification.customerId} " + $"- {notification.fullName} - {notification.email}");

            //TODO: Here you can publish the notification to the broker using MassTransit.
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling the CustomerCreatedNotification.");
        }

        return Task.CompletedTask;
    }
}

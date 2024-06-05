using MassTransit;
using Microsoft.Extensions.Logging;
using Core.Domain.Notifications;

namespace Core.Application.Consumers;

public class CustomerCreatedConsumer : IConsumer<CustomerCreatedNotification>
{
    private readonly ILogger<CustomerCreatedConsumer> logger;

    public CustomerCreatedConsumer(ILogger<CustomerCreatedConsumer> logger)
    {
        this.logger = logger;
    }
    public Task Consume(ConsumeContext<CustomerCreatedNotification> context)
    {
        try
        {
            var message = context.Message;
            if (message is not null)
            {
                logger.LogInformation($"Message received: \nId => {message.customerId} \nName => {message.fullName}\nEmail => {message.email}");
            }
            else
            {
                logger.LogWarning("Message is null");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error handling the CustomerCreatedNotification.");
        }

        return Task.CompletedTask;
    }
}
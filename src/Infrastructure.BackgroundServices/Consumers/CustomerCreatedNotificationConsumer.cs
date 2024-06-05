using Core.Domain.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

public class CustomerCreatedNotificationConsumer : INotificationHandler<CustomerCreatedNotification>
{
    public Task Handle(CustomerCreatedNotification notification, CancellationToken cancellationToken)
    {
        //Log data console.
     
        return Task.CompletedTask;
    }
}

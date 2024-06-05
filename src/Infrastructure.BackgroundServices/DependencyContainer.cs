

using Core.Domain.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.BackgroundServices;

public static class DependencyContainer
{
    public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler<CustomerCreatedNotification>, CustomerCreatedNotificationConsumer>();
        return services;
    }
}

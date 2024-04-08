using Core.Application;
using Infrastructure.DataAccess.SQLServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddEstabloDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationLayer();
        services.RegisterDataAccessLayer(configuration);
        return services;
    }
}

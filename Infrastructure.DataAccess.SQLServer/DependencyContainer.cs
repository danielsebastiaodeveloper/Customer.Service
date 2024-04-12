
using Core.Domain.Abstractions;
using Infrastructure.DataAccess.SQLServer.Context;
using Mexico.Developers.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.DataAccess.SQLServer;

public static class DependencyContainer
{
    public static IServiceCollection RegisterDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EstabloCustomerDBContext>(options =>
        options.UseSqlServer(Environment.GetEnvironmentVariable("EstabloCustomerDBConnectionString")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddRepositories<int, int, EstabloCustomerDBContext>();
        return services;
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.DataAccess.SQLServer.Context.Factories;

public class EstabloCustomerDBContextFactory : IDesignTimeDbContextFactory<EstabloCustomerDBContext>
{
    public EstabloCustomerDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EstabloCustomerDBContext>();
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("EstabloCustomerDBConnectionString"));

        return new EstabloCustomerDBContext(optionsBuilder.Options);
    }
}

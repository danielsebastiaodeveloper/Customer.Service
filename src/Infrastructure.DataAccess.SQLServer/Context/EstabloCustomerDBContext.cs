using Core.Domain.Pocos;
using Establo.Customer.Core.Domain.Pocos;
using Mexico.Developers.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.SQLServer.Context;

public class EstabloCustomerDBContext: DbContext
{
    public EstabloCustomerDBContext(DbContextOptions<EstabloCustomerDBContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<PointsTransaction> PointsTransactions { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.RegisterEntityConfigurations<EstabloCustomerDBContext>();
    }
}

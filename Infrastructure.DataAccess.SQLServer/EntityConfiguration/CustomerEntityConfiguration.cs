using Establo.Customer.Core.Domain.Pocos;
using Mexico.Developers.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.SQLServer.EntityConfiguration;
public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ConfigurationBase<int,int,Customer>("Customers");
        builder.Property(x => x.PhoneNumber).HasColumnType("varchar(15)").IsRequired(true);
        builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired(false);
        builder.Property(x => x.FullName).HasColumnType("varchar(150)").IsRequired(true);
    }
}

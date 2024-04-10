using Core.Domain.Pocos;
using Mexico.Developers.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.SQLServer.EntityConfiguration;

public class PointsTransactionEntityConfiguration : IEntityTypeConfiguration<PointsTransaction>
{
    public void Configure(EntityTypeBuilder<PointsTransaction> builder)
    {
        builder.ConfigurationBase<int, int, PointsTransaction>("PointsTransactions");
        builder.Property(p => p.Points).HasColumnType("decimal(18,2)");
        builder.Property(p => p.Description).HasMaxLength(255).IsRequired(false);
        builder.Property(p => p.TransactionDate).IsRequired(true);
        builder.Property(p => p.CustomerId).IsRequired(true);

        builder.HasOne(p => p.Customer)
               .WithMany(c => c.PointsTransactions)
               .HasForeignKey(p => p.CustomerId)
               .IsRequired(); 
    }
}

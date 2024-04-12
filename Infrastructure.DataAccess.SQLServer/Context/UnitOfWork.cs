using Core.Domain.Abstractions;

namespace Infrastructure.DataAccess.SQLServer.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly EstabloCustomerDBContext _establoCustomerDBContext;

    public UnitOfWork(EstabloCustomerDBContext establoCustomerDBContext) => _establoCustomerDBContext = establoCustomerDBContext;
   
    public Task SaveChangesAsync(CancellationToken cancellationToken = default) => _establoCustomerDBContext    .SaveChangesAsync(cancellationToken);
}

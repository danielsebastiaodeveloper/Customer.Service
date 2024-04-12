using Establo.Customer.Core.Domain.Abstractions;
using Establo.Customer.Core.Domain.Pocos;
using Infrastructure.DataAccess.SQLServer.Context;
using Mexico.Developers.Core.Abstractions;
using Mexico.Developers.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.SQLServer.Repositories;

public class CustomerRepository : RepositoryBase<int, int>, ICustomerRepository
{
    public CustomerRepository(EstabloCustomerDBContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TEntity>> GetAllCustomerWithTransactionsAsync<TEntity>(bool state, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>
    {
        if (!typeof(Customer).IsAssignableFrom(typeof(TEntity)))
        {
            throw new InvalidOperationException("TEntity debe ser un Customer o un tipo derivado de Customer.");
        }

        var transactionsWithCustomers = await base.Context.Set<Customer>()
            .AsNoTracking()
            .Where(p => p.State == state)
            .Include(p => p.PointsTransactions)
            .ToListAsync(cancellationToken);

        
        return transactionsWithCustomers.Cast<TEntity>();

    }

    public async Task<TEntity?> GetCustomerWithTransactionsAsync<TEntity>(int id, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>
    {
        if (!typeof(Customer).IsAssignableFrom(typeof(TEntity)))
        {
            throw new InvalidOperationException("TEntity debe ser un Customer o un tipo derivado de Customer.");
        }

        var transactionsWithCustomers = await base.Context.Set<Customer>()
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Include(p => p.PointsTransactions)
            .FirstOrDefaultAsync(cancellationToken);


        return transactionsWithCustomers as TEntity;
    }
}

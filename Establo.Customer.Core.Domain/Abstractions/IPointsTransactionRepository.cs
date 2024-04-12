using Establo.Customer.Core.Domain.Pocos;
using Mexico.Developers.Core.Abstractions;

namespace Core.Domain.Abstractions;

public interface IPointsTransactionRepository : IRepositoryBase<int, int>
{
    // Get all points transactions with customer
    public Task<IEnumerable<TEntity>> GetAllPointsTransactionWithCustomerAsync<TEntity>(bool state, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>;
    
    // Get points transaction with customer
    public Task<TEntity?> GetPointsTransactionWithCustomerAsync<TEntity>(int id, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>;

    // Insert points transaction
    public Task<bool> InserPointByStoredProcedureAsync(int customerId, decimal points, string description, int userCreatorId, CancellationToken cancellationToken);

    public Task<TEntity> InserPointAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>;

}
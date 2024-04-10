using Mexico.Developers.Core.Abstractions;

namespace Establo.Customer.Core.Domain.Abstractions;

/// <summary>
/// Represents the interface for a customer repository.
/// </summary>
public interface ICustomerRepository : IRepositoryBase<int, int>
{
    /// <summary>
    /// Retrieves all customers with their transactions asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="state">The state of the customers.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of customers with their transactions.</returns>
    public Task<IEnumerable<TEntity>> GetAllCustomerWithTransactionsAsync<TEntity>(bool state, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>;

    /// <summary>
    /// Retrieves a customer with their transactions asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="id">The ID of the customer.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the customer with their transactions, or null if not found.</returns>
    public Task<TEntity?> GetCustomerWithTransactionsAsync<TEntity>(int id, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>;
}

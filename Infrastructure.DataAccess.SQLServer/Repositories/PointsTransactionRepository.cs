using Microsoft.EntityFrameworkCore;
using Mexico.Developers.Core.Abstractions;
using Mexico.Developers.EFCore.Repositories;
using Core.Domain.Abstractions;
using Core.Domain.Pocos;
using Infrastructure.DataAccess.SQLServer.Context;
using Microsoft.Data.SqlClient;
using System.Data;
using Mexico.Developers.Core.Exceptions;

namespace Infrastructure.DataAccess.SQLServer.Repositories;

public class PointsTransactionRepository : RepositoryBase<int, int>, IPointsTransactionRepository
{
    public PointsTransactionRepository(EstabloCustomerDBContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TEntity>> GetAllPointsTransactionWithCustomerAsync<TEntity>(bool state, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>
    {
        if (!typeof(PointsTransaction).IsAssignableFrom(typeof(TEntity)))
        {
            throw new InvalidOperationException("TEntity debe ser un PointsTransaction o un tipo derivado de PointsTransaction.");
        }

        var transactionsWithCustomers = await base.Context.Set<PointsTransaction>()
            .Where(p => p.State == state)
            .Include(p => p.Customer)
            .ToListAsync(cancellationToken);


        return transactionsWithCustomers.Cast<TEntity>();


    }

    public async Task<TEntity?> GetPointsTransactionWithCustomerAsync<TEntity>(int id, CancellationToken cancellationToken) where TEntity : class, IEntityBase<int, int>
    {
        if (!typeof(PointsTransaction).IsAssignableFrom(typeof(TEntity)))
        {
            throw new InvalidOperationException("TEntity debe ser un PointsTransaction o un tipo derivado de PointsTransaction.");
        }

        var transactionsWithCustomers = await base.Context.Set<PointsTransaction>()
            .Where(p => p.Id == id)
            .Include(p => p.Customer)
            .FirstOrDefaultAsync(cancellationToken);

        return transactionsWithCustomers as TEntity;
    }

    public async Task<bool> InserPointByStoredProcedureAsync(int customerId, decimal points, string description, int userCreatorId, CancellationToken cancellationToken)
    {
        var customerIdParam = new SqlParameter { ParameterName = "@CustomerId", SqlDbType = SqlDbType.Int, Value = customerId };
        var pointsParam = new SqlParameter { ParameterName = "@Points", SqlDbType = SqlDbType.Decimal, Value = points };
        var descriptionParam = new SqlParameter { ParameterName = "@Description", SqlDbType = SqlDbType.VarChar, Value = description };
        var userCreatorIdParam = new SqlParameter { ParameterName = "@UserCreatorId", SqlDbType = SqlDbType.Int, Value = userCreatorId };
        var outputStatus = new SqlParameter { ParameterName = "@OutputStatus", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
        //var returnParameter = new SqlParameter { ParameterName = "@ReturnVal", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.ReturnValue };

        await Context.Database.ExecuteSqlRawAsync("EXEC InsertCustomerPointsAndUpdateTotal @CustomerId, @Points, @Description, @UserCreatorId, @OutputStatus OUT", customerIdParam, pointsParam, descriptionParam, userCreatorIdParam, outputStatus);

        var success = ((int)outputStatus.Value == 0);
        if (!success)
        {
            throw new ApiException($"Point is not generated for the customer {customerId}");
        }
        return success;
    }
    public async Task<bool> InsertPointByStoredProcedureAsync(int customerId, decimal points, string description, int userCreatorId, CancellationToken cancellationToken)
    {
        var parameters = new[]
        {
            new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customerId },
            new SqlParameter("@Points", SqlDbType.Decimal) { Value = points },
            new SqlParameter("@Description", SqlDbType.VarChar) { Value = description },
            new SqlParameter("@UserCreatorId", SqlDbType.Int) { Value = userCreatorId },
            new SqlParameter("@OutputStatus", SqlDbType.Int) { Direction = ParameterDirection.Output }
        };

        await Context.Database.ExecuteSqlRawAsync("EXEC InsertCustomerPointsAndUpdateTotal @CustomerId, @Points, @Description, @UserCreatorId, @OutputStatus OUT", parameters);

        var success = ((int)parameters[4].Value == 0);
        if (!success)
        {
            throw new ApiException($"Point is not generated for the customer {customerId}");
        }
        return success;
    }
}

using Establo.Customer.Core.Domain.Abstractions;
using Infrastructure.DataAccess.SQLServer.Context;
using Mexico.Developers.EFCore.Repositories;

namespace Infrastructure.DataAccess.SQLServer.Repositories;

public class CustomerRepository : RepositoryBase<int, int>, ICustomerRepository
{
    public CustomerRepository(EstabloCustomerDBContext context) : base(context)
    {
    }
}

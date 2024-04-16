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
}

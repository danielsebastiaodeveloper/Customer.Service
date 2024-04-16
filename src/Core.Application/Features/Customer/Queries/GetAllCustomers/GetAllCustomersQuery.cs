using Core.Application.DTOs;
using Core.Application.Mappers;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using Establo.Customer.Core.Domain.Pocos;
using MediatR;

namespace Core.Application.Features.Customer.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<Response<IEnumerable<CustomerReadDTO>>>
{
    /// <summary>
    /// Gets or sets the state of the customers.
    /// </summary>
    public bool State { get; set; } = true;
}

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, Response<IEnumerable<CustomerReadDTO>>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <summary>
    /// Handles the GetAllCustomersQuery request.
    /// </summary>
    /// <param name="request">The GetAllCustomersQuery request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response containing the list of customer DTOs.</returns>
    public async Task<Response<IEnumerable<CustomerReadDTO>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
       
        var customers = await _customerRepository.GetAllAsync<Establo.Customer.Core.Domain.Pocos.Customer>(request.State, cancellationToken);
        var dto = customers.Select(c => c.ToCustomerReadDTO()).ToList();
        return new Response<IEnumerable<CustomerReadDTO>>(dto, "Customers retrieved successfully.");
    }
}


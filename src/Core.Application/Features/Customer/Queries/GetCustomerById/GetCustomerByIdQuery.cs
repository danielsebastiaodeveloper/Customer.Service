using Core.Application.DTOs;
using Core.Application.Mappers;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using MediatR;

namespace Core.Application.Features.Customer.Queries.GetCustomerById;

/// <summary>
/// Represents a query to get a customer by ID.
/// </summary>
public class GetCustomerByIdQuery : IRequest<Response<CustomerReadDTO>>
{
    /// <summary>
    /// Gets or sets the ID of the customer.
    /// </summary>
    public int Id { get; set; } = default!;
}
public class GetCustomerByIdAndSortKeyQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerReadDTO>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdAndSortKeyQueryHandler(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    /// <summary>
    /// Handles the GetCustomerByIdQuery and returns the customer with the specified ID.
    /// </summary>
    /// <param name="request">The GetCustomerByIdQuery request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A response containing the customer with the specified ID.</returns>
    public async Task<Response<CustomerReadDTO>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetAsync<Establo.Customer.Core.Domain.Pocos.Customer>(request.Id, cancellationToken);

        var dto = result is null ? null : result?.ToCustomerReadDTO();

        return new Response<CustomerReadDTO>
        {
            Success = true,
            Data = dto
        };
    }
}



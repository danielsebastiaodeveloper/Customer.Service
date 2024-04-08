using Core.Application.DTOs;
using Core.Application.Mappers;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using Establo.Customer.Core.Domain.Pocos;
using MediatR;

namespace Core.Application.Features.Customer.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<Response<IEnumerable<CustomerReadDTO>>>
{
    public bool State { get; set; } = true;
}

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, Response<IEnumerable<CustomerReadDTO>>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<Response<IEnumerable<CustomerReadDTO>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetAllAsync<Establo.Customer.Core.Domain.Pocos.Customer>(request.State, cancellationToken);

        var dto = result is null ? [] : result.ToReadCustomerDTO();

        return new Response<IEnumerable<CustomerReadDTO>>
        {
            Success = true,
            Data = dto
        };
    }
}

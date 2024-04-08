using Core.Application.DTOs;
using Core.Application.Mappers;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using MediatR;

namespace Core.Application.Features.Customer.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<Response<CustomerReadDTO>>
{
    public int Id { get; set; } = default!;
}
public class GetCustomerByIdAndSortKeyQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerReadDTO>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdAndSortKeyQueryHandler(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }
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
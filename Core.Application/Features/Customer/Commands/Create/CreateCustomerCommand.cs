using Core.Application.Mappers;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using MediatR;

namespace Core.Application.Features.Customer.Commands.Create;

public class CreateCustomerCommand : IRequest<Response<int>>
{
    public string FullName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string? Email { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository clienteRepository)
    {
        _customerRepository = clienteRepository;
    }

    public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();
        var result = await _customerRepository.CreateItemAsync(customer, cancellationToken);
        var response = new Response<int>()
        {
            Data = result,
            Success = result > 0 ? true: false
        };
        return response;
    }
}
using MediatR;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using Core.Application.Mappers;

namespace Core.Application.Features.Customer.Commands.Update;

public class UpdateCustomerCommand : IRequest<Response<bool>>
{
    public int Id { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string? Email { get; set; }
    public bool State { get; set; }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<bool>>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    public async Task<Response<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerMapped = request.ToCustomer();

        var result = await _customerRepository.UpdateItemAsync(customerMapped, cancellationToken);

        var response = new Response<bool>()
        {
            Data = result,
            Success = result
        };
        return response;
    }
}
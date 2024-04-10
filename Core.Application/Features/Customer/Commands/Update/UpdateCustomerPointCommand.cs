using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using MediatR;

namespace Core.Application.Features.Customer.Commands.Update;

public class UpdateCustomerPointCommand : IRequest<Response<bool>>
{
    public int CustomerId { get; init; }
    public decimal Points { get; set; }
}

public class UpdateCustomerPointCommandHandler : IRequestHandler<UpdateCustomerPointCommand, Response<bool>>
{
    private readonly ICustomerRepository customerRepository;

    public UpdateCustomerPointCommandHandler(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<Response<bool>> Handle(UpdateCustomerPointCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetAsync<Establo.Customer.Core.Domain.Pocos.Customer>(request.CustomerId, cancellationToken);
        customer.Points += request.Points;
        var result = await customerRepository.UpdateItemAsync(customer, cancellationToken);
        return new Response<bool>
        {
            Data = result,
            Success = result
        };
    }
}

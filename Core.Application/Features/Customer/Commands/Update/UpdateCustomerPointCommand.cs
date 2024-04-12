using Core.Application.Wrappers;
using Core.Domain.Abstractions;
using Establo.Customer.Core.Domain.Abstractions;
using MediatR;
using Mexico.Developers.Core.Exceptions;

namespace Core.Application.Features.Customer.Commands.Update;

public class UpdateCustomerPointCommand : IRequest<Response<bool>>
{
    public int CustomerId { get; init; }
    public decimal Points { get; set; }
}

public class UpdateCustomerPointCommandHandler : IRequestHandler<UpdateCustomerPointCommand, Response<bool>>
{
    private readonly ICustomerRepository customerRepository;
    private readonly IUnitOfWork unitOfWork;

    public UpdateCustomerPointCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        this.customerRepository = customerRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Response<bool>> Handle(UpdateCustomerPointCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetAsync<Establo.Customer.Core.Domain.Pocos.Customer>(request.CustomerId, cancellationToken);
        if (customer is null)
        {
            throw new EntityNotFoundException($"Customer with Id {request.CustomerId} not found");
        }
        customer.Points += request.Points;
        await customerRepository.UpdateItemAsync(customer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new Response<bool>
        {
            Data = true,
            Success = true
        };
    }
}

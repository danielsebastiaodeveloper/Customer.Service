using MediatR;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;

namespace Core.Application.Features.Customer.Commands.Delete;

public class DeleteCustomerCommand : IRequest<Response<bool>>
{
    public int Id { get; set; } = default!;
}


public class DeleteCustomerBySortKeyCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<bool>>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerBySortKeyCommandHandler(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    public async Task<Response<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.DeleteAsync<Establo.Customer.Core.Domain.Pocos.Customer>(request.Id, cancellationToken);
        var response = new Response<bool>
        {
            Success = result,
            Data = result
        };
        return response;
    }
}

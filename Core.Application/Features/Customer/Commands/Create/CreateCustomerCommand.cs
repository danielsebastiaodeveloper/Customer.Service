using MediatR;
using Core.Application.Mappers;
using Core.Application.Wrappers;
using Core.Domain.Abstractions;
using Establo.Customer.Core.Domain.Abstractions;

namespace Core.Application.Features.Customer.Commands.Create;

/// <summary>
/// Represents a command to create a new customer.
/// </summary>
public class CreateCustomerCommand : IRequest<Response<int>>
{
    /// <summary>
    /// Gets or sets the full name of the customer.
    /// </summary>
    public string FullName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the phone number of the customer.
    /// </summary>
    public string PhoneNumber { get; set; } = default!;

    /// <summary>
    /// Gets or sets the email address of the customer.
    /// </summary>
    public string? Email { get; set; }
}

/// <summary>
/// Represents a handler for the CreateCustomerCommand.
/// </summary>
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCustomerCommandHandler"/> class.
    /// </summary>
    /// <param name="clienteRepository">The customer repository.</param>
    public CreateCustomerCommandHandler(ICustomerRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = clienteRepository;
        this.unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handles the CreateCustomerCommand.
    /// </summary>
    /// <param name="request">The CreateCustomerCommand to handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A response containing the ID of the created customer.</returns>
    public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToCustomer();
        await _customerRepository.CreateItemAsync(customer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        var response = new Response<int>()
        {
            Data = customer.Id,
            Success = customer.Id > 0 ? true : false
        };
        return response;
    }
}

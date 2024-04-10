using Core.Application.Mappers;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using MediatR;

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

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCustomerCommandHandler"/> class.
    /// </summary>
    /// <param name="clienteRepository">The customer repository.</param>
    public CreateCustomerCommandHandler(ICustomerRepository clienteRepository)
    {
        _customerRepository = clienteRepository;
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
        var result = await _customerRepository.CreateItemAsync(customer, cancellationToken);
        var response = new Response<int>()
        {
            Data = result,
            Success = result > 0 ? true : false
        };
        return response;
    }
}

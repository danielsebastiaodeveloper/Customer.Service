using MediatR;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using Core.Application.Mappers;

namespace Core.Application.Features.Customer.Commands.Update;

/// <summary>
/// Represents a command to update a customer.
/// </summary>
public class UpdateCustomerCommand : IRequest<Response<bool>>
{
    /// <summary>
    /// Gets or sets the ID of the customer.
    /// </summary>
    public int Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the full name of the customer.
    /// </summary>
    public string FullName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the phone number of the customer.
    /// </summary>
    public string PhoneNumber { get; set; } = default!;

    /// <summary>
    /// Gets or sets the email of the customer.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the state of the customer.
    /// </summary>
    public bool State { get; set; }

}

/// <summary>
/// Represents a handler for the UpdateCustomerCommand.
/// </summary>
public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<bool>>
{
    private readonly ICustomerRepository _customerRepository;

    /// <summary>
    /// Initializes a new instance of the UpdateCustomerCommandHandler class.
    /// </summary>
    /// <param name="customerRepository">The customer repository.</param>
    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    /// <summary>
    /// Handles the UpdateCustomerCommand.
    /// </summary>
    /// <param name="request">The UpdateCustomerCommand to handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A response indicating the success of the update operation.</returns>
    public async Task<Response<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerMapped = request.ToCustomer();

        var result = await _customerRepository.UpdateItemAsync(customerMapped, cancellationToken);

        var response = new Response<bool>
        {
            Data = result,
            Success = result
        };
        return response;
    }
}

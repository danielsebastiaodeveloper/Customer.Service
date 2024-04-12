using MediatR;
using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Abstractions;
using Core.Domain.Abstractions;

namespace Core.Application.Features.Customer.Commands.Delete
{
    /// <summary>
    /// Represents a command to delete a customer.
    /// </summary>
    public class DeleteCustomerCommand : IRequest<Response<bool>>
    {
        /// <summary>
        /// Gets or sets the ID of the customer to delete.
        /// </summary>
        public int Id { get; set; } = default!;
    }
}

namespace Core.Application.Features.Customer.Commands.Delete
{
    /// <summary>
    /// Represents a command handler for deleting a customer.
    /// </summary>
    public class DeleteCustomerBySortKeyCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCustomerBySortKeyCommandHandler"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository.</param>
        public DeleteCustomerBySortKeyCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles the delete customer command.
        /// </summary>
        /// <param name="request">The delete customer command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response indicating the success of the delete operation.</returns>
        public async Task<Response<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteAsync<Establo.Customer.Core.Domain.Pocos.Customer>(request.Id, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            var response = new Response<bool>
            {
                Success = true,
                Data = true
            };
            return response;
        }
    }
}

using FluentValidation;

namespace Core.Application.Features.Customer.Commands.Delete
{
    /// <summary>
    /// Validator for the DeleteCustomerCommand.
    /// </summary>
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCustomerValidator"/> class.
        /// </summary>
        public DeleteCustomerValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}

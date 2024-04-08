using FluentValidation;

namespace Core.Application.Features.Customer.Commands.Delete
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}

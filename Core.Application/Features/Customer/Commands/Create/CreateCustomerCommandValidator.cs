using FluentValidation;

namespace Core.Application.Features.Customer.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.FullName)
        .NotEmpty()
        .WithMessage("{PropertyName} is required")
        .NotNull()
        .WithMessage("{PropertyName} can not be null")
        .MaximumLength(150)
        .WithMessage("{PropertyName} must not exceed 150 characters");

        RuleFor(c => c.PhoneNumber)
         .NotEmpty()
         .WithMessage("{PropertyName} is required")
         .NotNull()
         .WithMessage("{PropertyName} can not be null");

        RuleFor(c => c.Email)
         .EmailAddress()
         .WithMessage("{PropertyName} is not a valid email address")
         .NotEmpty()
         .WithMessage("{PropertyName} is required")
         .NotNull()
         .WithMessage("{PropertyName} can not be null");
    }
}

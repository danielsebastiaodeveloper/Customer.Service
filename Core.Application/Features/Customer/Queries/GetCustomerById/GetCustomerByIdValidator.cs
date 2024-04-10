using FluentValidation;

namespace Core.Application.Features.Customer.Queries.GetCustomerById;

public class GetCustomerByIdValidator : AbstractValidator<GetCustomerByIdQuery>
{
    /// <summary>
    /// Validates the GetCustomerByIdQuery object.
    /// </summary>
    public GetCustomerByIdValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} can not be empty")
            .NotNull()
            .WithMessage("{PropertyName} can not be null");
    }
}

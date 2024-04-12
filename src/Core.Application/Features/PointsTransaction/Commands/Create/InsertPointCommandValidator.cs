using FluentValidation;

namespace Core.Application.Features.PointsTransaction.Commands.Create;


public class InsertPointCommandValidator : AbstractValidator<InsertPointCommand>
{
    /// <summary>
    /// Validates the InsertPointCommand.
    /// </summary>
    public InsertPointCommandValidator()
    {
        RuleFor(c => c.CustomerId)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .WithMessage("{PropertyName} can not be null");

        RuleFor(c => c.Points)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .WithMessage("{PropertyName} can not be null");
    }
}

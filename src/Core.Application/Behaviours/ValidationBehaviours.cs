using FluentValidation;
using MediatR;


namespace Core.Application.Behaviours;

/// <summary>
/// Represents a pipeline behavior for request validation.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehaviours{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">The validators to be used for request validation.</param>
    public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    /// <summary>
    /// Handles the request and performs request validation.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <param name="next">The delegate representing the next handler in the pipeline.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response of the request.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var contexto = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll(validators.Select(v => v.ValidateAsync(contexto, cancellationToken)));
            var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count != 0)
            {
                throw new Core.Application.Exceptions.ValidationException(failures);
            }
        }
        return await next();
    }
}

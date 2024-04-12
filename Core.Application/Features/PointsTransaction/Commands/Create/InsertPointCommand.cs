using MediatR;
using Core.Application.Mappers;
using Core.Application.Wrappers;
using Core.Domain.Abstractions;

namespace Core.Application.Features.PointsTransaction.Commands.Create;

/// <summary>
/// Represents a command to insert a new points transaction.
/// </summary>
public class InsertPointCommand : IRequest<Response<bool>>
{
    /// <summary>
    /// Gets or sets the customer ID.
    /// </summary>
    public int CustomerId { get; init; }

    /// <summary>
    /// Gets or sets the points.
    /// </summary>
    public decimal Points { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// Represents a handler for the InsertPointCommand.
/// </summary>
public class InsertPointCommandHandler : IRequestHandler<InsertPointCommand, Response<bool>>
{
    private readonly IPointsTransactionRepository pointsTransactionRepository;
    private readonly IMediator mediator;
    private readonly IUnitOfWork unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertPointCommandHandler"/> class.
    /// </summary>
    /// <param name="pointsTransactionRepository">The points transaction repository.</param>
    public InsertPointCommandHandler(IPointsTransactionRepository pointsTransactionRepository, IMediator mediator, IUnitOfWork unitOfWork)
    {
        this.pointsTransactionRepository = pointsTransactionRepository;
        this.mediator = mediator;
        this.unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handles the InsertPointCommand and creates a new points transaction.
    /// </summary>
    /// <param name="request">The InsertPointCommand request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response containing the result of the operation.</returns>
    public async Task<Response<bool>> Handle(InsertPointCommand request, CancellationToken cancellationToken)
    {
        var result = await pointsTransactionRepository.InserPointByStoredProcedureAsync(request.CustomerId, request.Points, request.Description, 1, cancellationToken);
        //var point = request.ToTransaction();
        //var result = await pointsTransactionRepository.InserPointAsync(point, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        var response = new Response<bool>
        {
            Data = result,
            Success = result,
        };
        return response;
    }
}


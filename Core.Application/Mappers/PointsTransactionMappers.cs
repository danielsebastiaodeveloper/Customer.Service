using Core.Application.DTOs;
using Core.Application.Features.PointsTransaction.Commands.Create;
using Core.Domain.Pocos;

namespace Core.Application.Mappers;

public static class PointsTransactionMappers
{
    /// <summary>
    /// Converts a <see cref="PointsTransaction"/> object to a <see cref="PointsTransactionDTO"/> object.
    /// </summary>
    /// <param name="pointsTransaction">The <see cref="PointsTransaction"/> object to convert.</param>
    /// <returns>The converted <see cref="PointsTransactionDTO"/> object.</returns>
    public static PointsTransactionDTO ToPointsTransactionDTO(this PointsTransaction pointsTransaction)
    {
        return new PointsTransactionDTO
        {
            Id = pointsTransaction.Id,
            CustomerId = pointsTransaction.CustomerId,
            TransactionDate = pointsTransaction.TransactionDate,
            Points = pointsTransaction.Points,
            Description = pointsTransaction.Description
        };
    }

    /// <summary>
    /// Converts a list of <see cref="PointsTransaction"/> objects to a list of <see cref="PointsTransactionDTO"/> objects.
    /// </summary>
    /// <param name="pointsTransactions">The list of <see cref="PointsTransaction"/> objects to convert.</param>
    /// <returns>The converted list of <see cref="PointsTransactionDTO"/> objects.</returns>
    public static ICollection<PointsTransactionDTO> ToPointsTransactionDTO(this ICollection<PointsTransaction> pointsTransactions)
    {
        return pointsTransactions.Select(x => x.ToPointsTransactionDTO()).ToList();
    }

    /// <summary>
    /// Converts an <see cref="InsertPointCommand"/> object to a <see cref="PointsTransaction"/> object.
    /// </summary>
    /// <param name="command">The <see cref="InsertPointCommand"/> object to convert.</param>
    /// <returns>The converted <see cref="PointsTransaction"/> object.</returns>
    public static PointsTransaction ToTransaction(this InsertPointCommand command)
    {
        return new PointsTransaction
        {
            Id = default,
            CustomerId = command.CustomerId,
            TransactionDate = DateTime.Now,
            Points = command.Points,
            Description = command.Description
        };
    }
}

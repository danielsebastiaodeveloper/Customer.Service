using Establo.Customer.Core.Domain.Abstractions;
using Establo.Customer.Core.Domain.Pocos;

namespace Core.Domain.Pocos;

public class PointsTransaction : EntityBase<int, int>
{
    public int CustomerId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Points { get; set; }
    public string? Description { get; set; }
    public Customer Customer { get; set; } = default!;
}

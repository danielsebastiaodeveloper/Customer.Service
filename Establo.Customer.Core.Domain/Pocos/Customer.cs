using Core.Domain.Pocos;
using Establo.Customer.Core.Domain.Abstractions;
using Mexico.Developers.Core.Abstractions;

namespace Establo.Customer.Core.Domain.Pocos;

public class Customer: Persona<int, int>
{
    public string PhoneNumber { get; set; } = default!;
    public string? Email { get; set; }
    public decimal Points { get; set; } = default;
    public ICollection<PointsTransaction> PointsTransactions { get; set; } = new List<PointsTransaction>();
}

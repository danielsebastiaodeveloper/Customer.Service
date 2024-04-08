using Establo.Customer.Core.Domain.Abstractions;
using Mexico.Developers.Core.Abstractions;

namespace Establo.Customer.Core.Domain.Pocos;

public class Customer: Persona<int, int>
{
    public string PhoneNumber { get; set; } = default!;
    public string? Email { get; set; }
}

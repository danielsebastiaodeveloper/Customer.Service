namespace Establo.Customer.Core.Domain.Abstractions;

public class Persona<TKey, TUserKey> : EntityBase<TKey, TUserKey>
{
    public string FullName { get; set; } = default!;
}

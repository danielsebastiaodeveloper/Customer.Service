using Mexico.Developers.Core.Abstractions;

namespace Establo.Customer.Core.Domain.Abstractions;

public abstract class EntityBase<TKey, TUserKey> : IEntityBase<TKey, TUserKey>
{
    public required TKey Id { get ; init ; }
    public bool State { get; set ; } = default!;
    public TUserKey UserCreatorId { get ; set ; } = default!;
    public DateTime CreatedDate { get ; set ; } = default!;
}

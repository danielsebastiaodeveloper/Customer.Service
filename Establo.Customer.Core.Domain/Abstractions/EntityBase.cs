using Mexico.Developers.Core.Abstractions;

namespace Establo.Customer.Core.Domain.Abstractions;

/// <summary>
/// Represents the base class for entities in the domain.
/// </summary>
/// <typeparam name="TKey">The type of the entity's identifier.</typeparam>
/// <typeparam name="TUserKey">The type of the user identifier.</typeparam>
public abstract class EntityBase<TKey, TUserKey> : IEntityBase<TKey, TUserKey>
{
    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    public required TKey Id { get; init; }

    /// <summary>
    /// Gets or sets the state of the entity.
    /// </summary>
    public bool State { get; set; } = default!;

    /// <summary>
    /// Gets or sets the user identifier who created the entity.
    /// </summary>
    public TUserKey UserCreatorId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the created date of the entity.
    /// </summary>
    public DateTime CreatedDate { get; set; } = default!;

    protected EntityBase(TKey id) => Id = id;

    protected EntityBase()
    {
    }
}


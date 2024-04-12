using Core.Domain.Primitives;
using Establo.Customer.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Abstractions;

public abstract class AggregateRoot<TKey, TUserKey> : EntityBase<TKey, TUserKey>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected AggregateRoot(TKey Id): base(Id)
    {
    }

    protected AggregateRoot()
    {
    }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);

}

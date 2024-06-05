using Core.Domain.Primitives;

namespace Core.Domain.Notifications;
public record CustomerCreatedNotification(int customerId, string fullName, string? email) : IDomainEvent {}


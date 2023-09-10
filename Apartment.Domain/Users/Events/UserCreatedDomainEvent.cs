using Apartment.Domain.Abstractions;

namespace Apartment.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;

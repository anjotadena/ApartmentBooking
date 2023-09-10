using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;

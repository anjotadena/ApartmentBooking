using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
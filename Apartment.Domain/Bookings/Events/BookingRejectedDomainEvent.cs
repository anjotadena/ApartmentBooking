using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Bookings.Events;

public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;

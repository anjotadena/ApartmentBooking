using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;

using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;

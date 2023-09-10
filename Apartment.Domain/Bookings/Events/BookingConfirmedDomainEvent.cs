using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid bookingId) : IDomainEvent;

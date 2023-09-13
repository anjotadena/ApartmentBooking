using ApartmentBooking.Application.Abstractions.Messaging;
namespace ApartmentBooking.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;

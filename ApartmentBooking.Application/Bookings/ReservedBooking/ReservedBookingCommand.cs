using ApartmentBooking.Application.Abstractions.Messaging;

namespace ApartmentBooking.Application.Bookings.ReservedBooking;

public record ReservedBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate
) : ICommand<Guid>;

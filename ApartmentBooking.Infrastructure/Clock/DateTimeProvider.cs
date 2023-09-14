using ApartmentBooking.Application.Abstractions.Clock;

namespace ApartmentBooking.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

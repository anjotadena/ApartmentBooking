using ApartmentBooking.Domain.Apartments;
using ApartmentBooking.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace ApartmentBooking.Infrastructure.Repositories;

internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatuses =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

    public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Apartment Add(Booking booking, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Booking>()
                              .AnyAsync(booking =>
                                            booking.ApartmentId == apartment.Id &&
                                            booking.Duration.Start <= duration.End &&
                                            booking.Duration.End >= duration.Start &&
                                            ActiveBookingStatuses.Contains(booking.Status),
                                        cancellationToken);
    }
}

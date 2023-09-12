using ApartmentBooking.Domain.Apartments;

namespace ApartmentBooking.Domain.Bookings;

public interface IBookingRepository
{
    Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(Apartment apartment, DateRange dateRange, CancellationToken cancellationToken = default);

    Apartment Add(Booking booking, CancellationToken cancellationToken = default);
}

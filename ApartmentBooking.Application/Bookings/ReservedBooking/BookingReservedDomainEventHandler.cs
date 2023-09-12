using ApartmentBooking.Application.Abstractions.Email;
using ApartmentBooking.Domain.Bookings;
using ApartmentBooking.Domain.Bookings.Events;
using ApartmentBooking.Domain.Users;
using MediatR;

namespace ApartmentBooking.Application.Bookings.ReservedBooking;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(IBookingRepository bookingRepository, IUserRepository userRepository, IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId);

        if (booking is null)
        {
            return;
        }

        var user = await _userRepository.GetByIdAsync(booking.UserId);

        if (user is null)
        {
            return;
        }

        await _emailService.SendAsync(user.Email, "Booking Reserved!", "You have 10 minutes to confirm this booking");
    }
}

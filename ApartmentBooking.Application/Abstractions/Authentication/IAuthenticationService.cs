using ApartmentBooking.Domain.Users;

namespace ApartmentBooking.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(User user, string password, CancellationToken cancellationToken = default);
}

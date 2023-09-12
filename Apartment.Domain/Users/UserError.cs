using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Users;

public static class UserError
{
    public static Error NotFound = new("User.Found", "The user with the specified identifier was not found");
}

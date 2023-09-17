using ApartmentBooking.Application.Abstractions.Messaging;

namespace ApartmentBooking.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password) : ICommand<Guid>;

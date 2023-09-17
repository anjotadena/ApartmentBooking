namespace ApartmentBooking.Api.Requests.Users;

public sealed record RegiserUserRequest(string Email, string FirstName, string LastName, string Password);

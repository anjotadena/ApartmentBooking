namespace ApartmentBooking.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Users.Email recepient, string subject, string body);
}

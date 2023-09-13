namespace ApartmentBooking.Application.Abstractions.Behaviors;

public sealed record ValidationError(string PropertyName, string ErrorMessage);

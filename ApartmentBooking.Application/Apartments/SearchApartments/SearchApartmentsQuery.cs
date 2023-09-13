using ApartmentBooking.Application.Abstractions.Messaging;

namespace ApartmentBooking.Application.Apartments.SearchApartments;

public sealed record SearchApartmentsQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
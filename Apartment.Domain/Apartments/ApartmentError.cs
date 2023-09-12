using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Apartments;

public static class ApartmentError
{
    public static Error NotFound = new("Apartment.Found", "The apartment with the specified identifier was not found");
}

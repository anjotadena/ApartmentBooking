using ApartmentBooking.Domain.Shared;

namespace ApartmentBooking.Domain.Bookings;

public record PricingDatails(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);
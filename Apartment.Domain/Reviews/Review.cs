using ApartmentBooking.Domain.Abstractions;

namespace ApartmentBooking.Domain.Reviews;

public class Review : Entity
{
    public Review(Guid id) : base(id)
    {
    }
}

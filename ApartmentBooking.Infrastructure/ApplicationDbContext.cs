using ApartmentBooking.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ApartmentBooking.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}

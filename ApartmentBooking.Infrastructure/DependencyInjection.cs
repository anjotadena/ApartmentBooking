using ApartmentBooking.Application.Abstractions.Clock;
using ApartmentBooking.Application.Abstractions.Data;
using ApartmentBooking.Application.Abstractions.Email;
using ApartmentBooking.Domain.Abstractions;
using ApartmentBooking.Domain.Apartments;
using ApartmentBooking.Domain.Bookings;
using ApartmentBooking.Domain.Users;
using ApartmentBooking.Infrastructure.Clock;
using ApartmentBooking.Infrastructure.Data;
using ApartmentBooking.Infrastructure.Email;
using ApartmentBooking.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApartmentBooking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        // Add support for our postgres
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}

using ApartmentBooking.Application.Abstractions.Authentication;
using ApartmentBooking.Application.Abstractions.Clock;
using ApartmentBooking.Application.Abstractions.Data;
using ApartmentBooking.Application.Abstractions.Email;
using ApartmentBooking.Domain.Abstractions;
using ApartmentBooking.Domain.Apartments;
using ApartmentBooking.Domain.Bookings;
using ApartmentBooking.Domain.Users;
using ApartmentBooking.Infrastructure.Authentication;
using ApartmentBooking.Infrastructure.Clock;
using ApartmentBooking.Infrastructure.Data;
using ApartmentBooking.Infrastructure.Email;
using ApartmentBooking.Infrastructure.Repositories;
using Dapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ApartmentBooking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        AddPersistence(services, configuration);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));

        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.Configure<KeycloakOptions>(configuration.GetSection("Keycloak"));

        services.AddTransient<AdminAuthorizationDelegatingHandler>();
        services.AddHttpClient<IAuthenticationService, AuthenticationService>((serviceProvider, httpClient) =>
                {
                    var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;

                    httpClient.BaseAddress = new Uri(keycloakOptions.AdminUrl);
                })
                .AddHttpMessageHandler<AdminAuthorizationDelegatingHandler>();

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
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
    }
}

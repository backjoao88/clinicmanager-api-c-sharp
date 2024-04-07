using ClinicManager.Application.Shared.Services.Authentication;
using ClinicManager.Application.Shared.Services.Email.Contracts;
using ClinicManager.Application.Shared.Services.GoogleCalendar;
using ClinicManager.Domain.Repositories;
using ClinicManager.Infrastructure.Persistence;
using ClinicManager.Infrastructure.Persistence.Configurations;
using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManager.Infrastructure.Services.Authentication;
using ClinicManager.Infrastructure.Services.Authentication.Options;
using ClinicManager.Infrastructure.Services.Email;
using ClinicManager.Infrastructure.Services.Email.Options;
using ClinicManager.Infrastructure.Services.Email.Providers;
using ClinicManager.Infrastructure.Services.GoogleCalendar;
using ClinicManager.Infrastructure.Services.GoogleCalendar.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace ClinicManager.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddJwt(this IServiceCollection services)
    {
        services
            .ConfigureOptions<JwtOptionsSetup>()
            .ConfigureOptions<JwtBearerOptionsSetup>()
            .AddScoped<IJwtService, JwtService>();
        return services;
    }

    public static IServiceCollection AddGoogleCalendar(this IServiceCollection services)
    {
        services
            .ConfigureOptions<GoogleCalendarCredentialsOptionsSetup>()
            .AddScoped<IGoogleCalendarService, GoogleCalendarService>();
        return services;
    }
    
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services
            .ConfigureOptions<AppDbContextOptionsSetup>()
            .AddDbContext<AppDbContext>(((provider, builder) =>
            {
                var appDbContextOptions =
                    provider.GetService(typeof(IOptions<AppDbContextOptions>)) as IOptions<AppDbContextOptions>;
                if (appDbContextOptions is null) return;
                builder.UseSqlServer(appDbContextOptions.Value.ConnectionString);
            }))
            .AddScoped<IUnitOfWork, AppUnitOfWork>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IPatientRepository, PatientRepository>()
            .AddScoped<IDoctorRepository, DoctorRepository>()
            .AddScoped<IAppointmentRepository, AppointmentRepository>()
            .AddScoped<ICredentialRepository, CredentialRepository>();
        return services;
    }

    public static IServiceCollection AddEmail(this IServiceCollection services)
    {
        services
            .ConfigureOptions<EmailOptionsSetup>()
            .AddScoped<IIcsProvider, IcsProvider>()
            .AddScoped<INotificationService, EmailNotificationService>();
        return services;
    }
    
    public static IServiceProvider RunMigrations(this IServiceProvider provider)
    {
        var scope = provider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        return provider;
    }
}
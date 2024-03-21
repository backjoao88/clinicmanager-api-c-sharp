using ClinicManager.Application.Shared.Email.Contracts;
using ClinicManager.Domain.Repositories;
using ClinicManager.Infrastructure.Persistence;
using ClinicManager.Infrastructure.Persistence.Configurations;
using ClinicManager.Infrastructure.Persistence.Repositories;
using ClinicManager.Infrastructure.Services.Email;
using ClinicManager.Infrastructure.Services.Email.Options;
using ClinicManager.Infrastructure.Services.Email.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClinicManager.Infrastructure;

public static class DependencyInjection
{
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
            .AddScoped<IPatientRepository, PatientRepository>()
            .AddScoped<IDoctorRepository, DoctorRepository>()
            .AddScoped<IAppointmentRepository, AppointmentRepository>();
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
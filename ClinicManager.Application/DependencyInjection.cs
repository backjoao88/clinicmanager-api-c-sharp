using ClinicManager.Application.Appointments.Services;
using ClinicManager.Application.Appointments.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddConfirmationLinkService(this IServiceCollection services)
    {
        services
            .AddScoped<ILinkProvider, LinkProvider>();
        return services;
    }
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        return services;
    }
}
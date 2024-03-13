using Microsoft.Extensions.DependencyInjection;

namespace ClinicManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        return services;
    }
}
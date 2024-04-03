using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClinicManager.Infrastructure.Persistence.Configurations;

/// <summary>
/// Sets up a <see cref="AppDbContextOptions"/>
/// </summary>
public class AppDbContextOptionsSetup : IConfigureOptions<AppDbContextOptions>
{
    private IConfiguration _configuration;
    private const string AppDbContextSectionName = "Database";
    public AppDbContextOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(AppDbContextOptions options)
    {
        _configuration.GetSection(AppDbContextSectionName).Bind(options);
    }
}
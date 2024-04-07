using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClinicManager.Infrastructure.Services.GoogleCalendar.Options;

public class GoogleCalendarCredentialsOptionsSetup : IConfigureOptions<GoogleCalendarCredentialsOptions>
{
    private readonly IConfiguration _configuration;
    private const string GoogleCalendarApplicationCredentialsSectionName = "Calendar:Credentials";

    public GoogleCalendarCredentialsOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Binds the current calendar credentials section in the app configuration to a <see cref="GoogleCalendarCredentialsOptions"/> options class.
    /// </summary>
    /// <param name="options"></param>
    public void Configure(GoogleCalendarCredentialsOptions options)
    {
        _configuration.GetSection(GoogleCalendarApplicationCredentialsSectionName).Bind(options);
    }
}
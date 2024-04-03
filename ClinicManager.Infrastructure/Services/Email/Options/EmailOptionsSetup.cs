using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClinicManager.Infrastructure.Services.Email.Options;

/// <summary>
/// Sets up an <see cref="EmailOptions"/> options.
/// </summary>
public class EmailOptionsSetup : IConfigureOptions<EmailOptions>
{
    private const string EmailNotificationSectionName = "Email";
    private readonly IConfiguration _configuration;

    public EmailOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EmailOptions options)
    {
        _configuration.GetSection(EmailNotificationSectionName).Bind(options);
    }
}
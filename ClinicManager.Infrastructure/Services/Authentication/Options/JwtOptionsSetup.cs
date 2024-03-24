using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClinicManager.Infrastructure.Services.Authentication.Options;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string JwtSectionName = "Jwt";
    private readonly IConfiguration _configuration;
    
    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Bind the current JWT configurations from settings into the JWT options object.
    /// </summary>
    /// <param name="options"></param>
    public void Configure(JwtOptions options)
    { 
        _configuration.GetSection(JwtSectionName).Bind(options);
    }
}
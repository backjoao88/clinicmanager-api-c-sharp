using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ClinicManager.Application.Shared.Authentication;
using ClinicManager.Domain.Core.Users.Enumerations;
using ClinicManager.Infrastructure.Services.Authentication.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Encoding = System.Text.Encoding;

namespace ClinicManager.Infrastructure.Services.Authentication;

public class JwtService : IJwtService
{
    private readonly JwtOptions _jwtOptions;

    public JwtService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    /// <inheritdoc/>
    public string Generate(Guid userId, ERole role)
    {
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.PrivateKey));
        var audience = _jwtOptions.Audience;
        var issuer = _jwtOptions.Issuer;
        var header = new JwtHeader(new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha512));
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(ClaimTypes.Role, role.ToString())
        };
        var payload = new JwtPayload(issuer, audience, claims, DateTime.Now, DateTime.Now.AddHours(6));
        var jwt = new JwtSecurityToken(header, payload);
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtString = jwtHandler.WriteToken(jwt);
        return jwtString;
    }

    /// <inheritdoc/>
    public string Encrypt(string str)
    {
        var crypt = SHA512.Create();
        var encryptedBytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
        var builder = new StringBuilder();
        foreach(var byteChunk in encryptedBytes)
        {
            builder.Append($"{byteChunk:X2}");
        }
        return builder.ToString();
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ClinicManager.Application.Shared.Services.Authentication;
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
    public string GenerateAuthenticationToken(Guid userId, ERole role)
    {
        const int MINUTES_TO_EXPIRE = 480;
        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(new JwtSecurityToken(GenerateJwtHeader(), GenerateJwtPayload(new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim("role", role.ToString())
        }, MINUTES_TO_EXPIRE)));
    }

    /// <summary>
    /// Generates a JWT token payload.
    /// </summary>
    /// <param name="claims"></param>
    /// <param name="minutesToExpire"></param>
    /// <returns></returns>
    private JwtPayload GenerateJwtPayload(List<Claim> claims, int minutesToExpire)
    {
        var startExpires = DateTime.Now;
        var expiresDate = startExpires.AddMinutes(minutesToExpire);
        return new JwtPayload(_jwtOptions.Issuer, _jwtOptions.Audience, claims, startExpires, expiresDate);
    }
    
    /// <summary>
    /// Generates a JWT token header.
    /// </summary>
    /// <returns></returns>
    private JwtHeader GenerateJwtHeader()
    {
        var wrappedPrivateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.PrivateKey));
        return new JwtHeader(new SigningCredentials(wrappedPrivateKey, SecurityAlgorithms.HmacSha512));
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
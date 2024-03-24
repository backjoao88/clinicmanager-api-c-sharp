using ClinicManager.Domain.Core.Users.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace ClinicManager.Api.Attributes;

/// <summary>
/// Represents a has permission attribute
/// </summary>
public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(params ERole[] roles)
    {
        var loweredRoles = roles.Select(o => o.ToString().ToString()).ToArray();
        Roles = string.Join(", ", loweredRoles);
    } 
}
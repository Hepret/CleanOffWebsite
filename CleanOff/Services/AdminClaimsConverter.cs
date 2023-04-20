using System.Security.Claims;
using CleanOff.Domain;
using CleanOff.Domain.Users;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CleanOff.Services;

public class AdminClaimsConverter
{
    public static ClaimsPrincipal Convert(Admin admin)
    {
        var claims = new Claim[]
        {
            new Claim("id", admin.AdminId.ToString()),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(identity);
        return claimsPrincipal;
    }
}
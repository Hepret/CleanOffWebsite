using System.Security.Claims;
using CleanOff.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CleanOff.Services;

public static class ClientClaimsConverter
{
    public static ClaimsPrincipal Convert(Client client)
    {
        var claims = new Claim[]
        {
            new Claim("id", client.ClientId.ToString()),
            new Claim(ClaimTypes.Role, "Client")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(identity);
        return claimsPrincipal;
    }
}
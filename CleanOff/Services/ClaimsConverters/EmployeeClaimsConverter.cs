using System.Security.Claims;
using CleanOff.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CleanOff.Services;

public static class EmployeeClaimsConverter
{
    public static ClaimsPrincipal Convert(Employee employee)
    {
        var claims = new Claim[]
        {
            new Claim("id", employee.EmployeeId.ToString()),
            new Claim(ClaimTypes.Role, "Employee")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(identity);
        return claimsPrincipal;
    }
}
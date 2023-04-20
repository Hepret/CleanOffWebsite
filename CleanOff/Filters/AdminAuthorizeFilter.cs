using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanOff.Filters;

public class AdminAuthorizeFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (user.Identity != null && (!user.Identity.IsAuthenticated || !user.IsInRole("Admin")))
        {
            context.Result = new RedirectToActionResult("Login","Admin", null);
            
        }
        return;
    }
}
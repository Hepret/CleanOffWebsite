using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanOff.Filters;

public class ClientAuthorizationFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (user.Identity != null && (!user.Identity.IsAuthenticated || !user.IsInRole("Client")))
        {
            context.Result = new RedirectToActionResult("Index","Profile", null);
            
        }
        return;
    }
}
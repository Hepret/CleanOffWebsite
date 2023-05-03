using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanOff.Filters;

public class UserAuthorizeFilter  : Attribute, IAuthorizationFilter
{
    private readonly string _role;
    private readonly string _controllerName;

    public UserAuthorizeFilter(string role, string controllerName)
    {
        _role = role;
        _controllerName = controllerName;
    }
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        
        if (SkipAuthorization(context)) return;
        
        if (user.Identity != null && (!user.Identity.IsAuthenticated || !user.IsInRole(_role)))
        {
            context.Result = new RedirectToActionResult("Login",_controllerName, null);
        }
        return;
    }
    
    private static bool SkipAuthorization(AuthorizationFilterContext context)
    {
        var actionAttributes = context.ActionDescriptor.EndpointMetadata;

        return actionAttributes.Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));
    }

}
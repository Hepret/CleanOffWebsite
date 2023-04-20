using CleanOff.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class ProfileController: Controller
{
    [HttpGet("profile/signIn")]
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("profile")]
    [ClientAuthorizationFilter]
    public IActionResult UserAccount()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class ProfileController: Controller
{
    [Route("profile/signIn")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("profile")]
    [Authorize(Roles = "Client")]
    public IActionResult UserAccount()
    {
        return View();
    }
}
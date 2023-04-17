using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class ProfileController: Controller
{
    [Route("profile/signIn")]
    public IActionResult Index()
    {
        return View();
    }
    [Route("profile")]
    public IActionResult Useraccount()
    {
        return View();
    }
}
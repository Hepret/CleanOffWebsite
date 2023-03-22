using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class ProfileController: Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Useraccount()
    {
        return View();
    }
}
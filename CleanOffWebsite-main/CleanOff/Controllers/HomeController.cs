using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return Ok();
    }

    public IActionResult Login()
    {
        return View("login");
    }
}
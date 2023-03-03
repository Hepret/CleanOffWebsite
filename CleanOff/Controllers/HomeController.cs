using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Content("Hello world");
    }
}
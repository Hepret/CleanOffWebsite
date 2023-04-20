using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    [HttpGet("admin")]
    public IActionResult Index()
    {
        return View();
    }
    
    
    
    
}
using CleanOff.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class ApiController : Controller
{
    public IActionResult Login()
    {
        return BadRequest();
    }

    public IActionResult Register()
    {
        return BadRequest();
    }

    public IActionResult GetUserOrders(Client client)
    {
        return BadRequest();
    }

    public IActionResult GetOrderItems()
    {
        return BadRequest();
    }

    public IActionResult GetOrderInfo(Order order)
    {
        return BadRequest();
    }

    public IActionResult CreateOrder(Order order)
    {
        return BadRequest();
    }

    public IActionResult UpdateOrder(Order order)
    {
        return BadRequest();
    }
    
}
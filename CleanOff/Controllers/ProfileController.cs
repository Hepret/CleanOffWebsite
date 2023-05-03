using System.Security.Claims;
using CleanOff.Domain;
using CleanOff.Domain.Users;
using CleanOff.Filters;
using CleanOff.Services;
using CleanOff.Services.UserManagers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

[Controller]
[Route(("/{controller}"))]
public class ProfileController: Controller
{
    private readonly IClientManager _clientManager;
    private readonly OrderService _orderService;

    public ProfileController(IClientManager clientManager, OrderService orderService)
    {
        _clientManager = clientManager;
        _orderService = orderService;
    }

    [HttpGet("signIn")]
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("")]
    [ClientAuthorizationFilter]
    public IActionResult UserAccount()
    {
        return View();
    }

    [ClientAuthorizationFilter]
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Profile");
    }

    [HttpPost("create_order")]
    public async Task<IActionResult> CreateOrder(OrderViewModel orderViewModel)
    {
        var client = await GetClient();
        orderViewModel.Client = client;
        var order = new Order(orderViewModel);
        try
        {
            await _orderService.CreateOrder(order);
        }
        catch (Exception e)
        {
            return BadRequest("Не удалось создать заказ попробуйте еще раз");
        }
        return Ok("Заказ создан");
    }

    [NonAction]
    private async Task<Client> GetClient()
    {
        var clientId = Guid.Parse(HttpContext.User.FindFirstValue("id")!); 
        return (await _clientManager.FindClientById(clientId))!;
    }
}
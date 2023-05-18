using System.Security.Claims;
using CleanOff.Domain;
using CleanOff.Domain.Users;
using CleanOff.Domain.ViewModels;
using CleanOff.Filters;
using CleanOff.Services;
using CleanOff.Services.UserManagers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

[Controller]
[Route(("/[controller]"))]
public class ProfileController: Controller
{
    private readonly IClientManager _clientManager;
    private readonly OrderService _orderService;

    public ProfileController(IClientManager clientManager, OrderService orderService)
    {
        _clientManager = clientManager;
        _orderService = orderService;
    }

    #region Авторизация пользователя

    [HttpGet("signIn")]
    [AllowAnonymous]
    public IActionResult Index()
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
    #endregion

    [HttpGet("")]
    [ClientAuthorizationFilter]
    public async Task<IActionResult> UserAccount()
    {
        var client = await GetClient();
        return View(client);
    }

    

    [HttpPost("createOrder")]
    public async Task<IActionResult> CreateOrder(OrderViewModel orderViewModel)
    {
        var date = await Request.ReadFromJsonAsync<OrderViewModel>();
        
        var client = await GetClient();
        var order = new Order(date)
        {
            Client = client
        };
        try
        {
            await _orderService.CreateOrderAsync(order);
            return Ok("Заказ создан");
        }
        catch (Exception e)
        {
            return BadRequest("Ошибка создания заказа");
            throw;
        }
    }

    [NonAction]
    private async Task<Client> GetClient()
    {
        var clientId = Guid.Parse(HttpContext.User.FindFirstValue("id")!); 
        return (await _clientManager.FindClientById(clientId))!;
    }
}
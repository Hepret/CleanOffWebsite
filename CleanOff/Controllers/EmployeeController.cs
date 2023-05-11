using System.Security.Claims;
using CleanOff.Domain.Users;
using CleanOff.Domain.ViewModels;
using CleanOff.Exceptions;
using CleanOff.Filters;
using CleanOff.Models;
using CleanOff.Services;
using CleanOff.Services.UserManagers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;


[Controller]
[Route("/[controller]")]
[TypeFilter(typeof(UserAuthorizeFilter), Arguments = new object[]{"Employee", "Employee"})]
public class EmployeeController : Controller
{
    private readonly IEmployeeManager _employeeManager;
    private readonly IClientManager _clientManager;
    private readonly OrderService _orderService;


    public EmployeeController(ApplicationDbContext dbContext, IEmployeeManager employeeManager, IClientManager clientManager, OrderService orderService)
    {
        _employeeManager = employeeManager;
        _clientManager = clientManager;
        _orderService = orderService;
    } 
    [HttpGet("/[controller]")]
    public async Task<IActionResult> Index()
    {
        var newOrders = await _orderService.GetNewOrdersAsync();
        return View(newOrders);
    }

    
    #region Авторизация работника
    
    [HttpGet("login")]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(EmployeeLoginDto loginDto)
    {
        var email = loginDto.Email;
        var employee = await _employeeManager.FindByEmailAsync(email);
        if (employee == null) throw new DoesntExistException(email);
        var verifyPassword = _employeeManager.VerifyPassword(employee, loginDto.Password);
        if (!verifyPassword) throw new WrongPasswordException<Employee>(email);
        await Authenticate(employee);
        return RedirectToAction("Index");
    }
    
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [NonAction]
    async Task Authenticate(Employee employee)
    {
        var claimsPrincipals = EmployeeClaimsConverter.Convert(employee);
        await HttpContext.SignInAsync(claimsPrincipals);
    }
    [NonAction]
    public async Task<Employee> GetMe()
    {
        var employeeId = Guid.Parse(User.FindFirstValue("id") ?? throw new InvalidOperationException());
        return (await _employeeManager.FindByIdAsync(employeeId))!;
        
    }
    #endregion

    #region Создание заказов

    [HttpGet("createOrder")]
    public IActionResult CreateOrder()
    {
        return View();
    }
    #endregion

    #region Обработка заказов
    
    [HttpGet("order/check")]
    public async Task<IActionResult> CheckOrder(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null) BadRequest("Такого заказа не существует");
        return View(order);
    }
    
    
    [HttpGet("order")]
    public async Task<IActionResult> Order(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null) BadRequest("Такого заказа не существует");
        return View(order);
    }

    [HttpGet("order/check/confirm")]
    public async Task<IActionResult> ConfirmOrder(Guid orderId, decimal price)
    {

        var order = await _orderService.GetOrderByIdAsync(orderId);
        order.Price = price;
        var employee = await GetMe();
        order.Employee = employee;
        await _orderService.ConfirmOrder(order);
        return RedirectToAction(actionName: "Index");
    }
    
    [HttpGet("order/check/reject")]
    public async Task<IActionResult> RejectOrder(Guid orderId)
    {

        try
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            await _orderService.RejectOrderAsync(order);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest("Ошибка удаления заказа");
            Console.WriteLine(e);
            // TODO Добавить обработку ошиюок
            // TODO Добавить логирование
        }
        
    }

    [HttpGet("order/check/updateAndConfirm")]
    public async Task<IActionResult> UpdateAndConfirm(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        return View(order);
    }

    [HttpPost("order/check/updateAndConfirm")]
    public async Task<IActionResult> UpdateAndConfirm(Guid orderId, OrderViewModel orderViewModel)
    {
        try
        {   
            var order = await _orderService.GetOrderByIdAsync(orderId);
            order.Employee = await GetMe();
            order.Description = orderViewModel.Description;
            order.Address = orderViewModel.Address;
            order.Price = orderViewModel.Price;
            order.NeedDelivery = orderViewModel.NeedDelivery;
            await _orderService.ConfirmOrder(order);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest("Заказ не добавлен");
        }
        
        
    }
    [HttpGet("ordersList")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderService.GetCheckedAndInProgressOrdersAsync();
        return View(orders);
    }
    #endregion
    


    #region Профиль работника

    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        var employee = await GetMe();
        return View(employee);
    }

    #endregion
    [HttpGet("completeOrder")]
    public async Task<IActionResult> CompleteOrder(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        await _orderService.CompleteOrderAsync(order);
        return RedirectToAction("GetOrders");
    }

    [HttpGet("orderInProgress")]
    public async Task<IActionResult> InProgressOrder(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        await _orderService.InProgressOrder(order);
        return RedirectToAction("Order", routeValues: new { orderId = orderId });
    }
}
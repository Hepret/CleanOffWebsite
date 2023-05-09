using CleanOff.Domain;
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

    [NonAction]
    async Task Authenticate(Employee employee)
    {
        var claimsPrincipals = EmployeeClaimsConverter.Convert(employee);
        await HttpContext.SignInAsync(claimsPrincipals);
    }
    #endregion

    #region Создание заказов

    [HttpGet("create_order")]
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
    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null) BadRequest("Такого заказа не существует");
        return View(order);
    }

    [HttpPost("order/confirm")]
    public async Task<IActionResult> ConfirmOrder(Guid orderId, decimal price)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("order/reject")]
    public async Task<IActionResult> RejectOrder(Guid orderId)
    {

        try
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            await _orderService.RejectOrderAsync(order);
            return Ok("Заказ отменен");
        }
        catch (Exception e)
        {
            return BadRequest("Ошибка удаления заказа");
            Console.WriteLine(e);
            // TODO Добавить обработку ошиюок
            // TODO Добавить логирование
        }
        
    }
    
    #endregion
    
}
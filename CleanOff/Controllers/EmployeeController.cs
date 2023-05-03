using CleanOff.Domain;
using CleanOff.Domain.ViewModels;
using CleanOff.Exceptions;
using CleanOff.Filters;
using CleanOff.Models;
using CleanOff.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;


[Controller]
[Route("/[controller]")]
[TypeFilter(typeof(UserAuthorizeFilter), Arguments = new object[]{"Employee", "Employee"})]
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IEmployeeManager _employeeManager;
    private readonly IClientManager _clientManager;

    public EmployeeController(ApplicationDbContext dbContext, IEmployeeManager employeeManager, IClientManager clientManager)
    {
        _dbContext = dbContext;
        _employeeManager = employeeManager;
        _clientManager = clientManager;
    } 
    [HttpGet]
    public IActionResult Index()
    {
        // Основная страница
        throw new NotImplementedException();
    }

    
    #region Авторизация работника
    
    [HttpGet("login")]
    [AllowAnonymous]
    // [TypeFilter(typeof(AllowAnonymousFilter))]
    // [TypeFilter(typeof(UserAuthorizeFilter), Arguments = new object[]{"Employee", "Employee"})]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    // [TypeFilter(typeof(UserAuthorizeFilter), Arguments = new object[]{"Employee", "employee"})]

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

    

    #endregion
    
}
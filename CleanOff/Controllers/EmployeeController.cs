using CleanOff.Domain;
using CleanOff.Domain.ViewModels;
using CleanOff.Models;
using CleanOff.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;


[Controller]
[Route("/{controller}")]
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
        
    public IActionResult Index()
    {
        // Основная страница
        throw new NotImplementedException();
    }

    
    #region Авторизация работника
    
    [HttpPost("/login")]
    public IActionResult Login(EmployeeLoginDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpGet("/login")]
    [AllowAnonymous]
    public IActionResult Login()
    {
        throw new NotImplementedException();
    }
    
    #endregion

    #region Создание заказов
    

    #endregion

    #region Обработка заказов

    

    #endregion
    
}
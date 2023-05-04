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

[Route("/[controller]")]
[Controller]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IEmployeeManager _employeeManager;
    private readonly IAdminManager _adminManager;
    
    
    public AdminController(ApplicationDbContext dbContext, IEmployeeManager employeeManager, IAdminManager adminManager)
    {
        _dbContext = dbContext;
        _employeeManager = employeeManager;
        _adminManager = adminManager;
    }
    [AdminAuthorizeFilter]
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var employees = await _employeeManager.GetAllEmployeesAsync();
        var employeeViewModels = employees
            .Select(employee => new EmployeeViewModel(employee))
            .ToList();
        return View(employeeViewModels);
    }
    [AdminAuthorizeFilter]
    [HttpGet("createEmployee")]
    public IActionResult CreateEmployee()
    {
        return View();
    }
    [AdminAuthorizeFilter]
    [HttpPost("createEmployee")]
    public async Task<IActionResult> CreateEmployee(EmployeeRegisterDto registerDto)
    {
        var employee = new Employee(registerDto);

        try
        {
            await _employeeManager.CreateAsync(employee);
            TempData["EmployeeCreation"] = "succeed"; 
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["EmployeeCreation"] = "failed"; 
            return RedirectToAction("Index");
        }
    }

    [HttpGet("login")]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AdminLoginDto loginDto)
    {
        var email = loginDto.Email;
        var admin = await _adminManager.FindByEmailAsync(email);
        if (admin == null) throw new DoesntExistException(email);
        var verifyPassword = _adminManager.VerifyPassword(admin, loginDto.Password);
        if (!verifyPassword) throw new WrongPasswordException<Admin>(email);
        await Authenticate(admin);
        return RedirectToAction("Index");
    }

    [AdminAuthorizeFilter]
    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        var usr = User;
        var stringId = User.Claims.First(claim => claim.Type == "id").Value;
        var id = Guid.Parse(stringId);
        var admin = await _adminManager.FindByIdAsync(id);
        return View(admin!);
    }
    
    [AdminAuthorizeFilter]
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [NonAction]
    async Task Authenticate(Admin admin)
    {
        var claimsPrincipals = AdminClaimsConverter.Convert(admin);
        await HttpContext.SignInAsync(claimsPrincipals);
    }
}   
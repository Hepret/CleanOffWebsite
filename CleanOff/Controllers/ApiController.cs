using CleanOff.Domain;
using CleanOff.Exceptions;
using CleanOff.Models;
using CleanOff.Services;
using CleanOff.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IClientManager _clientManager;

    public ApiController(ApplicationDbContext dbContext, IClientManager clientManager)
    {
        _dbContext = dbContext;
        _clientManager = clientManager;
    }

    [AllowAnonymous]
    [Route("register")]
    [Route("api/register")]
    [HttpPost("register")]
    public async Task<IActionResult> Register(ClientRegisterDto registerDto)
    {
        var client = new Client(registerDto);
        try
        {
            await _clientManager.CreateAsync(client);
            await Authenticate(client);
            return Ok("Регистрация прошла успешно");
        }
        catch (ClientAlreadyExistException e)
        {
            // TODO Добавить логирование
            return BadRequest("Пользователь с такой почтой уже существует");
        }
        catch (Exception e)
        {
            // TODO Добавить логирование
            return BadRequest("Ошибка регистрации попробуйте позже");
        }
    }

    [HttpPost("login")]
    [Route("login")]
    [Route("api/login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(ClientLoginDto loginDto)
    {
        try
        {
            var email = loginDto.Email;
            var client = await _clientManager.FindClientByEmail(email);
            if (client == null) throw new ClientDoesntExistException(email);
            var verifyPassword = _clientManager.VerifyPassword(client, loginDto.Password);
            if (!verifyPassword) throw new WrongClientPasswordException(email);
            await Authenticate(client);
            return Ok("Вы успешно вошли");
        }
        catch (Exception e)
        {
            return BadRequest("Неправильно введнная почта или пароль");
        }
    }

    [HttpGet("getClients")] 
    public IEnumerable<Client> GetClients()
    {
        return _dbContext.Clients;
    }
    
    [HttpGet("getOrders")]
    public IEnumerable<Order> GetOrders()
    {
        return _dbContext.Orders;
    }

    [HttpGet("getItems")]
    public IEnumerable<OrderItem> GetItems()
    {
        return _dbContext.OrderItems;
    }

    [HttpGet("getEmployees")]
    public IEnumerable<Employee> GetEmployees()
    {
        return _dbContext.Employees;
    }

    [HttpPost("createClient")]
    public async Task<IActionResult> CreateClient(Client client)
    {
        try
        {
            await _dbContext.Clients.AddAsync(client);
            
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpPost("createEmployee")]
    public async Task<IActionResult> CreateEmployee(Employee employee)
    {
        try
        {
            await _dbContext.Employees.AddAsync(employee);
            
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
    
    [HttpPost("CreateOrderItem")]
    public async Task<IActionResult> CreateOrderItem(OrderItem orderItem)
    {
        try
        {
            await _dbContext.OrderItems.AddAsync(orderItem);
            
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [NonAction]
    private async Task Authenticate(Client client)
    {
        var claimsPrincipal = ClientClaimsConverter.Convert(client);
        await HttpContext.SignInAsync(claimsPrincipal);
    }
}
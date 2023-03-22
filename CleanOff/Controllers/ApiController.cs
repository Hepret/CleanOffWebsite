using CleanOff.Domain;
using CleanOff.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ApiController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
    
    
}
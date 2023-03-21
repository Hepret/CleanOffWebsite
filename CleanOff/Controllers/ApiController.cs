using CleanOff.Domain;
using CleanOff.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanOff.Controllers;

public class ApiController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ApiController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<Client> GetClients()
    {
        return _dbContext.Clients;
    }
    
    [HttpGet]
    public IEnumerable<Order> GetOrders()
    {
        return _dbContext.Orders;
    }

    [HttpGet]
    public IEnumerable<OrderItem> GetItems()
    {
        return _dbContext.OrderItems;
    }

    [HttpGet]
    public IEnumerable<Employee> GetEmployees()
    {
        return _dbContext.Employees;
    }

    [HttpPost]
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

    [HttpPost]
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
    
    [HttpPost]
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
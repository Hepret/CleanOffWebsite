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

    


}
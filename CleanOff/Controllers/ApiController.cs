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
    
}
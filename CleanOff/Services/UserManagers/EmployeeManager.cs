using CleanOff.Domain;
using CleanOff.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanOff.Services.UserManagers;

public class EmployeeManager : IEmployeeManager
{
    private readonly ApplicationDbContext _context;

    public EmployeeManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public bool VerifyPassword(Employee employee, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, employee.HashPassword);
    }

    public async Task<Employee?> FindByIdAsync(Guid id)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id)!;
    }

    public async Task<Employee?> FindByEmailAsync(string email)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email)!;

    }
    
}
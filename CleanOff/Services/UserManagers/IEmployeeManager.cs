using CleanOff.Domain;

namespace CleanOff.Services.UserManagers;

public interface IEmployeeManager
{
    public Task CreateAsync(Employee employee);
    public bool VerifyPassword(Employee employee, string password);
    public Task<Employee?> FindByIdAsync(Guid id);
    public Task<Employee?> FindByEmailAsync(string email);
    public Task<List<Employee>> GetAllEmployeesAsync();
}
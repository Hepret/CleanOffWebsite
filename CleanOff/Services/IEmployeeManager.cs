using CleanOff.Domain;

namespace CleanOff.Services;

public interface IEmployeeManager
{
    public Task CreateAsync(Employee employee);
    public bool VerifyPassword(Employee employee, string password);
    public Task<Employee?> FindById(Guid id);
    public Task<Employee?> FindByEmail(string email);
    public Task<List<Employee>> GetAllEmployees();
}
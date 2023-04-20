using CleanOff.Domain.Users;

namespace CleanOff.Services;

public interface IAdminManager
{
    public Task<Admin?> FindByEmailAsync(string email);
    public Task<Admin?> FindByIdAsync(Guid id);
    public Task CreateAsync(Admin admin);
    public bool VerifyPassword(Admin admin, string password);
}
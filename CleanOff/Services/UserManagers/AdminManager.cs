using CleanOff.Domain.Users;
using CleanOff.Exceptions.AlreadyExistExceptions;
using CleanOff.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanOff.Services.UserManagers;

public class AdminManager : IAdminManager
{
    private readonly ApplicationDbContext _context;

    public AdminManager(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Admin?> FindByEmailAsync(string email)
    {
        return await _context.Admins.FirstOrDefaultAsync(admin => admin!.Email == email);
    }

    public async Task<Admin?> FindByIdAsync(Guid id)
    {
        return await _context.Admins.FirstOrDefaultAsync(admin => admin!.AdminId == id);
    }

    public async Task CreateAsync(Admin admin)
    {
        var isAlreadyExist = await FindByEmailAsync(admin.Email) != null;
        if (isAlreadyExist)
        {
            throw new AdminAlreadyExistException(admin);
        }

        await _context.Admins.AddAsync(admin);
        await _context.SaveChangesAsync();
    }
    
    public bool VerifyPassword(Admin admin, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash);
    }
}
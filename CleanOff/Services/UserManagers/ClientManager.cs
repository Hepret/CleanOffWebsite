using CleanOff.Domain;
using CleanOff.Exceptions.AlreadyExistExceptions;
using CleanOff.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanOff.Services.UserManagers;

public class ClientManager : IClientManager
{
    private readonly ApplicationDbContext _context;

    public ClientManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Client client)
    {
        var isAlreadyExist = await FindClientByEmail(client.Email) != null;
        if (isAlreadyExist)
        {
            throw new ClientAlreadyExistException(client);
        }

        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public bool VerifyPassword(Client client, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, client.PasswordHash);
    }

    public async Task<Client?> FindClientById(Guid id)
    {
        var client = await  _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
        return client;
    }
    public async Task<Client?> FindClientByEmail(string email)
    {
        var client = await  _context.Clients.FirstOrDefaultAsync(c => c.Email == email);
        return client;
    }
}
using CleanOff.Domain;
using CleanOff.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanOff.Services;

public class ClientManager : IClientManager
{
    private readonly ApplicationDbContext _context;

    public ClientManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Client client)
    {
        try
        {
            var isAlreadyExist = await FindClientByEmail(client.Email) != null;
            if (isAlreadyExist)
            {
                throw new ClientAlreadyExistException(client);
            }

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }
        catch (ClientAlreadyExistException e)
        {
            throw;
        }
        catch (Exception e)
        {
            throw;
            // TODO Handle Exception when try add New Client To Database
        }

        

    }
    public async Task<Client?> FindClientById(Guid id)
    {
        var client = await  _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
        return client;
    }
    public async Task<Client?> FindClientByEmail(string email)
    {
        var client = await  _context.Clients.FirstOrDefaultAsync(c => c!.Email == email);
        return client;
    }
}
using CleanOff.Domain;

namespace CleanOff.Services.UserManagers;

public interface IClientManager
{
    public Task CreateAsync(Client client);
    public bool VerifyPassword(Client client, string password);
    public Task<Client?> FindClientById(Guid id);
    public Task<Client?> FindClientByEmail(string email);
}
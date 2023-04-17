using CleanOff.Domain;

namespace CleanOff.Services;

public interface IClientManager
{
    public Task CreateAsync(Client client);
    public Task<Client?> FindClientById(Guid id);
    public Task<Client?> FindClientByEmail(string email);
}
using CleanOff.Domain;

namespace CleanOff.Exceptions;

public class ClientAlreadyExistException : ArgumentException
{
    private readonly Client _client;
    
    public ClientAlreadyExistException(Client client) : base($"Client with email {client.Email} already Exist")
    {
        _client = client;
    }
    
    
}
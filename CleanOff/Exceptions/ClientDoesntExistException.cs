namespace CleanOff.Exceptions;

public class ClientDoesntExistException : ArgumentException
{
    public string Email { get; }

    public ClientDoesntExistException(string email)
    {
        Email = email;
    }

    public override string Message => $"Client with email: {Email} does not exist.";
}
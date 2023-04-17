namespace CleanOff.Exceptions;

public class WrongClientPasswordException : ArgumentException
{
    public string Email { get; }

    public WrongClientPasswordException(string email)
    {
        Email = email;
    }

    public override string Message => $"Wrong password for client with email {Email}.";
}
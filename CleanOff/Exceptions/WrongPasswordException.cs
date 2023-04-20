namespace CleanOff.Exceptions;

public class WrongPasswordException<T> : ArgumentException
{
    public WrongPasswordException(string email) : base($"{typeof(T).Name} с почтой: {email}")
    {
    }
}
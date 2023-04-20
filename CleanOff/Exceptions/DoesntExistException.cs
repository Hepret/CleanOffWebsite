namespace CleanOff.Exceptions;

public class DoesntExistException : ArgumentException
{
    public DoesntExistException(string email) : base($"Человека с электронной почтой: {email} - не существует в базе данных")
    {
    }
}
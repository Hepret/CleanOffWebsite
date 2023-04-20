using CleanOff.Domain.Users;

namespace CleanOff.Exceptions.AlreadyExistExceptions;

public class AdminAlreadyExistException : AlreadyExistException<Admin>
{
    public AdminAlreadyExistException(Admin admin) : base(admin)
    {
    }

    public override string Message => $"Администратор с электронной почтой: {_item.Email} - уже существует";
}
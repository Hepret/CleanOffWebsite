using CleanOff.Domain;

namespace CleanOff.Exceptions.AlreadyExistExceptions;

public class EmployeeAlreadyExistException : AlreadyExistException<Employee>
{
    public EmployeeAlreadyExistException(Employee employee) : base(employee)
    {
    }

    public override string Message => $"Пользователь с электронной почтой уже существует: {_item.Email}";
}
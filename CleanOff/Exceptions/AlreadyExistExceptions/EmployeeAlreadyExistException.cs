using CleanOff.Domain;
using CleanOff.Domain.Users;

namespace CleanOff.Exceptions.AlreadyExistExceptions;

public class EmployeeAlreadyExistException : AlreadyExistException<Employee>
{
    public EmployeeAlreadyExistException(Employee employee) : base(employee)
    {
    }

    public override string Message => $"Работник с электронной  почтой: {_item.Email} - уже существует";
}
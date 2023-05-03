using CleanOff.Domain.Users;

namespace CleanOff.Domain.ViewModels;

public class EmployeeViewModel
{
    public string Name { get; private set; }
    public string Surname { get; private set; } 
    public string Email { get; private set; }
    public Guid EmployeeId { get; private set; }

    public EmployeeViewModel(Employee employee)
    {
        Name = employee.Name;
        Surname = employee.Surname;
        Email = employee.Email;
        EmployeeId = employee.EmployeeId;
    }
    
}
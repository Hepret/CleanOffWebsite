using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.ViewModels;

namespace CleanOff.Domain;

public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid EmployeeId { get; set; }
    public string HashPassword { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Employee()
    { }

    public Employee(EmployeeRegisterDto registerDto)
    {
        EmployeeId = Guid.NewGuid();
        HashPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        Name = registerDto.Name;
        Surname = registerDto.Surname;
        Email = registerDto.Email;
        Phone = registerDto.Phone;
    }
}
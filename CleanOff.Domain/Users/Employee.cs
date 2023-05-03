using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.Domain.ViewModels;

namespace CleanOff.Domain.Users;

public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid EmployeeId { get; set; }

    public string HashPassword { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

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
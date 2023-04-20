using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.Domain.ViewModels;

namespace CleanOff.Domain.Users;

public class Admin 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid AdminId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Admin() {}
    public Admin(AdminRegisterDto registerDto){
        AdminId = Guid.NewGuid();
        Name = registerDto.Name;
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        Surname = registerDto.Surname;
        Email = registerDto.Email;
    }
}
using CleanOff.ViewModels;

namespace CleanOff.Domain.Users;

public class Admin 
{
    public Guid AdminId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    public Admin(AdminRegisterDto registerDto){
        AdminId = Guid.NewGuid();
        Name = registerDto.Name;
        HashPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        Surname = registerDto.Surname;
        Email = registerDto.Email;
    }
}
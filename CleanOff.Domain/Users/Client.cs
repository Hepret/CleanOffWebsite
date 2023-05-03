using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.Domain.ViewModels;

namespace CleanOff.Domain.Users;

public class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid ClientId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<Order> Orders { get; set; } = null!;
    
    public Client() {}

    public Client(ClientRegisterDto registerDto)
    {
        ClientId = Guid.NewGuid();
        Name = registerDto.Name;
        Surname = registerDto.Surname;
        Email = registerDto.Email;
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
    }
}
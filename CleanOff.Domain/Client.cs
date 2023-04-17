using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.ViewModels;

namespace CleanOff.Domain;

public class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid ClientId { get; set; }

    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<Order> Orders { get; set; } = null!;
    
    public Client() {}

    public Client(ClientRegisterDto registerDto)
    {
        ClientId = Guid.NewGuid();
        Name = registerDto.Name;
        Email = registerDto.Email;
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
    }
}
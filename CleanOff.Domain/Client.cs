using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.ViewModels;

namespace CleanOff.Domain;

public class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid ClientId { get; set; }
    public required string Name { get; set; }
    public required string PasswordHash { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
    
    public Client() {}

    public Client(ClientRegisterDto registerDto)
    {
        ClientId = Guid.NewGuid();
        Name = registerDto.Name;
        Email = registerDto.Email;
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
    }
}
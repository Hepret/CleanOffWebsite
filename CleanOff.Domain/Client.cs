using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.ViewModels;

namespace CleanOff.Domain;

public class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid ClientId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
    
    public Client() {}

    public Client(ClientRegisterDto registerDto)
    {
        ClientId = Guid.NewGuid();
        Name = registerDto.Name;
        Phone = registerDto.Phone;
        Email = registerDto.Email;
    }
}
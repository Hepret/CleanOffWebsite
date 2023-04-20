namespace CleanOff.Domain.Users;

public class Admin 
{
    public Guid AdminId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public string Email { get; set; } = null!;
}
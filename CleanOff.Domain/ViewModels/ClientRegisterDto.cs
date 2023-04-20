namespace CleanOff.Domain.ViewModels;

public class ClientRegisterDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Surname { get; set; } = null!;
}
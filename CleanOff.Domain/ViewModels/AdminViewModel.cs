using CleanOff.Domain.Users;

namespace CleanOff.Domain.ViewModels;

public class AdminViewModel
{
    public Guid AdminId { get; private set; }
    public string Name { get; private set; } 
    public string Surname { get; private set; } 
    public string Email { get; private set; } 
    
    public AdminViewModel(Admin admin)
    {
        AdminId = admin.AdminId;
        Name = admin.Name;
        Surname = admin.Surname;
        Email = admin.Email;
    }
}
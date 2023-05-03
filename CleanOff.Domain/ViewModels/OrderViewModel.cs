using CleanOff.Domain.Users;

namespace CleanOff.Domain.ViewModels;

public class OrderViewModel
{
    public Client Client { get; set; } = null!;
    public DateTime RequestDate { get; set; }
    public string Description { get; set; } = null!;
    public bool NeedDelivery { get; set; } 
}
using CleanOff.Domain.Users;

namespace CleanOff.Domain.ViewModels;

public class OrderViewModel
{
    public string RequestDateString { get; set; } 
    public string Description { get; set; } 
    public bool NeedDelivery { get; set; }
}
using CleanOff.Domain.Users;

namespace CleanOff.Domain.ViewModels;

public class OrderViewModel
{
    public string RequestDateString { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool NeedDelivery { get; set; }
    public string? Address { get; set; }
    public decimal? Price { get; set; }
}
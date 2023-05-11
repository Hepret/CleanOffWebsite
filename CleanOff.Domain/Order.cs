using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.Domain.Users;
using CleanOff.Domain.ViewModels;

namespace CleanOff.Domain;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid OrderId { get; set; }
    public OrderState OrderState { get; set; }
    public Client Client { get; set; } = null!;
    public Employee? Employee { get; set; } 
    public DateTime RequestDate { get; set; }
    public DateTime? DateOfIssue { get; set; }
    public string Description { get; set; } = null!;
    public bool NeedDelivery { get; set; }
    public decimal? Price { get; set; }
    public string? Address { get; set; }

    public Order()
    {
    }

    public Order(OrderViewModel orderViewModel)
    {
        OrderId = Guid.NewGuid();
        OrderState = OrderState.New;
        RequestDate = DateTime.Parse(orderViewModel.RequestDateString).ToUniversalTime();
        DateOfIssue = null;
        Description = orderViewModel.Description;
        NeedDelivery = orderViewModel.NeedDelivery;
        Address = orderViewModel.Address;
        Price = orderViewModel.Price;
    }
}
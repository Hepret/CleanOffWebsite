using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanOff.Domain.Users;

namespace CleanOff.Domain;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid OrderId { get; set; }
    public OrderState OrderState { get; set; }
    public Client Client { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
    public DateTime RequestDate { get; set; }
    public DateTime? DateOfIssue { get; set; }
    public string Description { get; set; } = null!;
    public decimal? Price { get; set; }

    public Order()
    {
    }

    public Order(OrderViewModel orderViewModel)
    {
        OrderState = OrderState.New;
        Client = orderViewModel.Client;
        RequestDate = orderViewModel.RequestDate;
        DateOfIssue = null;
        Description = orderViewModel.Description;
    }
}

public class OrderViewModel
{
    public Client Client { get; set; } = null!;
    public DateTime RequestDate { get; set; }
    public string Description { get; set; } = null!;   
}


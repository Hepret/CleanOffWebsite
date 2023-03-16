namespace CleanOff.Domain;

public class Order
{
    public int Id { get; set; }
    public OrderState OrderState { get; set; }
    public Client Client { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
    public DateTime RequestDate { get; set; }
    public DateTime DateOfIssue { get; set; }
    public List<OrderItems> OrderItems { get; set; }
    public decimal Price => OrderItems.Sum(items => items.Price);
}


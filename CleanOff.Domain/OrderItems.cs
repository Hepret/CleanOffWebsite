namespace CleanOff.Domain;

public class OrderItems
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public OrderItem OrderItem { get; set; } = null!;

    public decimal Price => OrderItem.Price * Amount;

}
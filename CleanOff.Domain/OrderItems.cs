using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanOff.Domain;

public class OrderItems
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid OrderItemsId { get; set; }
    public int Amount { get; set; }
    public OrderItem OrderItem { get; set; } = null!;

    public decimal Price => OrderItem.Price * Amount;

}
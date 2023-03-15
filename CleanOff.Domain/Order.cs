namespace CleanOff.Domain;

public class Order
{
    public int Id { get; set; }
    
    public OrderState OrderState { get; set; }
    
    public Client Client { get; set; }
    
    public Employee Employee { get; set; }

    public List<Service> Services { get; set; }
    
    public decimal? TotalCost => 
        Services.Sum(service => service.Price);
    
}

public class Service
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
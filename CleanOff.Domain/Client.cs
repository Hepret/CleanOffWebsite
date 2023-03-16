namespace CleanOff.Domain;

public class Client
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public List<Order> Orders { get; set; }
}
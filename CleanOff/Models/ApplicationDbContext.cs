using CleanOff.Domain;
using CleanOff.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanOff.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Admin?> Admins { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderItems> OrderItemsWithAmount { get; set; }
}
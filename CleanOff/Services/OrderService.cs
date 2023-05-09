using CleanOff.Domain;
using CleanOff.Domain.Users;
using CleanOff.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanOff.Services;

public class OrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(Order order)
    {
        try
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            // TODO Логирование создание заказа
        }
        catch
        {
            // TODO Логирование ошибка создание заказа
            throw;
        }
        
    }

    public async Task<List<Order>> GetClientOrdersAsync(Client client)
    {
        var orders =  await _context.Orders.Where(order => order.Client.ClientId == client.ClientId).ToListAsync();
        return orders;
    }

    public async Task<List<Order>> GetNewOrdersAsync()
    {
        var orders = await _context.Orders.Where(order => order.OrderState == OrderState.New).ToListAsync();
        return orders;
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        var order = await _context.Orders.Include(ord => ord.Client).FirstAsync(ord => ord.OrderId == orderId);
        return order;
    }

    public async Task RejectOrderAsync(Order order)
    {
        order.OrderState = OrderState.OrderDenied;
        await _context.SaveChangesAsync();
    }
}
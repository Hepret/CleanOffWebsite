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

    public async Task<List<Order>> GetClientOrders(Client client)
    {
        var order =  await _context.Orders.Where(order => order.Client.ClientId == client.ClientId).ToListAsync();
        return order;
    }

}
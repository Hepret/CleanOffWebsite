using CleanOff.Domain;
using CleanOff.Models;

namespace CleanOff.Services;

public class OrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrder(Order order)
    {
        try
        {
            await _context.Orders.AddAsync(order);
            // TODO Логирование создание заказа
        }
        catch
        {
            // TODO Логирование ошибка создание заказа
            throw;
        }
        
    }
    
}
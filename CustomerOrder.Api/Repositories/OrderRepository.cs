using CustomerOrder.Api.Data;
using CustomerOrder.Api.Entities;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Order> GetAll()
    {
        return _context.Orders
            .Include(o => o.Customer)   
            .ToList();
    }

    public Order? GetById(int id)
    {
        return _context.Orders.Include(o => o.Customer)
        .FirstOrDefault(o => o.OrderId==id);
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void Delete(Order order)
    {
        _context.Remove(order);
        _context.SaveChanges();
    }

    public void Update(Order order)
    {
        _context.Update(order);
        _context.SaveChanges();
    }
}
 
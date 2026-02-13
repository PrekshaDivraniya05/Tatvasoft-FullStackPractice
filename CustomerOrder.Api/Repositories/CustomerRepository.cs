using CustomerOrder.Api.Data;
using CustomerOrder.Api.Entities;
using CustomerOrder.Api.Pagination;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Customer> GetPaged(PaginationParams pagination)
    {
        return _context.Customers
            .Include(c => c.Orders)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToList();
    }

    public Customer? GetById(int id)
    {
        return _context.Customers
            .Include(c => c.Orders)
            .FirstOrDefault(c => c.CustomerId == id);
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    public void Delete(Customer customer)
    {
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    public bool Exists(int id)
    {
        return _context.Customers.Any(c => c.CustomerId == id);
    }
}

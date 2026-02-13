using CustomerOrder.Api.Entities;
using CustomerOrder.Api.Pagination;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repo;

    public CustomerService(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public List<CustomerResponseDTO> GetAll(PaginationParams pagination)
    {
        var customers = _repo.GetPaged(pagination);

        return customers.Select(c => new CustomerResponseDTO
        {
            CustomerId = c.CustomerId,
            Name = c.Name,
            TotalAmount = c.Orders.Sum(o => o.Amount)
        }).ToList();
    }

    public CustomerResponseDTO? GetById(int id)
    {
        var customer = _repo.GetById(id);
        if (customer == null) return null;

        return new CustomerResponseDTO
        {
            CustomerId = customer.CustomerId,
            Name = customer.Name,
            TotalAmount = customer.Orders.Sum(o => o.Amount)
        };
    }

    public void Create(CustomerCreateDTO dto)
    {
        var customer = new Customer
        {
            Name = dto.Name
        };

        _repo.Add(customer);
    }

    public bool Update(int id, CustomerUpdateDTO dto)
    {
        var customer = _repo.GetById(id);
        if (customer == null) return false;

        customer.Name = dto.Name;
        _repo.Update(customer);
        return true;
    }

    public bool Patch(int id, CustomerPatchDTO dto)
    {
        var customer = _repo.GetById(id);
        if (customer == null) return false;

        if (!string.IsNullOrWhiteSpace(dto.Name))
            customer.Name = dto.Name;

        _repo.Update(customer);
        return true;
    }

    public bool Delete(int id)
    {
        var customer = _repo.GetById(id);
        if (customer == null) return false;

        _repo.Delete(customer);
        return true;
    }
}

using CustomerOrder.Api.Entities;
using CustomerOrder.Api.Pagination;

public interface ICustomerRepository
{
    List<Customer> GetPaged(PaginationParams pagination);
    Customer? GetById(int id);
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(Customer customer);
    bool Exists(int id);
}

using CustomerOrder.Api.Pagination;

public interface ICustomerService
{
    List<CustomerResponseDTO> GetAll(PaginationParams pagination);
    CustomerResponseDTO? GetById(int id);
    void Create(CustomerCreateDTO dto);
    bool Update(int id, CustomerUpdateDTO dto);
    bool Patch(int id, CustomerPatchDTO dto);
    bool Delete(int id);
}

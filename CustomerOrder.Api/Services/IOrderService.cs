public interface IOrderService
{
    List<OrderResponseDTO> GetAll();
    OrderResponseDTO? GetById(int id);
    bool Create(OrderCreateDTO dto);
    bool Update(int id, OrderUpdateDTO dto);
    bool Patch(int id, OrderPatchDTO dto);
    bool Delete(int id);

    List<OrderResponseDTO>? GetOrdersByCustomerId(int customerId);
}

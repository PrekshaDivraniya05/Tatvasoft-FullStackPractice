using CustomerOrder.Api.Entities;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly ICustomerRepository _customerRepo;

    public OrderService(IOrderRepository orderRepo,
                        ICustomerRepository customerRepo)
    {
        _orderRepo = orderRepo;
        _customerRepo = customerRepo;
    }

    // public List<OrderResponseDTO> GetAll()
    // {
    //     var orders = _orderRepo.GetAll();

    //     return orders.Select(o => new OrderResponseDTO
    //     {
    //         OrderId = o.OrderId,
    //         Amount = o.Amount,
    //         OrderDate = o.OrderDate,
    //         CustomerId = o.CustomerId
    //     }).ToList();
    // }

    // public OrderResponseDTO? GetById(int id)
    // {
    //     var order = _orderRepo.GetById(id);
    //     if (order == null) return null;

    //     return new OrderResponseDTO
    //     {
    //         OrderId = order.OrderId,
    //         Amount = order.Amount,
    //         OrderDate = order.OrderDate,
    //         CustomerId = order.CustomerId
    //     };
    // }

    // public bool Create(OrderCreateDTO dto)
    // {
    //     // Validate Customer exists
    //     if (!_customerRepo.Exists(dto.CustomerId))
    //         return false;

    //     var order = new Order
    //     {
    //         Amount = dto.Amount,
    //         OrderDate = dto.OrderDate,
    //         CustomerId = dto.CustomerId
    //     };

    //     _orderRepo.Add(order);
    //     return true;
    // }

    // public bool Update(int id, OrderUpdateDTO dto)
    // {
    //     var order = _orderRepo.GetById(id);
    //     if (order == null) return false;

    //     order.Amount = dto.Amount;
    //     order.OrderDate = dto.OrderDate;

    //     _orderRepo.Update(order);
    //     return true;
    // }

    // public bool Patch(int id, OrderPatchDTO dto)
    // {
    //     var order = _orderRepo.GetById(id);
    //     if (order == null) return false;

    //     if (dto.Amount.HasValue)
    //         order.Amount = dto.Amount.Value;

    //     if (dto.OrderDate.HasValue)
    //         order.OrderDate = dto.OrderDate.Value;

    //     _orderRepo.Update(order);
    //     return true;
    // }

    // public bool Delete(int id)
    // {
    //     var order = _orderRepo.GetById(id);
    //     if (order == null) return false;

    //     _orderRepo.Delete(order);
    //     return true;
    // }

    public List<OrderResponseDTO> GetAll()
    {
        var orders = _orderRepo.GetAll();

        return orders.Select(o => new OrderResponseDTO
        {
            OrderId = o.OrderId,
            Amount = o.Amount,
            OrderDate = o.OrderDate,
            CustomerId = o.CustomerId
        }).ToList();
    }
    public OrderResponseDTO? GetById(int id)
    {
        var order = _orderRepo.GetById(id);
        if (order == null) return null;

        return new OrderResponseDTO
        {
            OrderId = order.OrderId,
            Amount = order.Amount,
            OrderDate = order.OrderDate,
            CustomerId = order.CustomerId
        };
    }
    public bool Create(OrderCreateDTO dto)
    {
        if (!_customerRepo.Exists(dto.CustomerId)) return false;

        var order = new Order
        {
            Amount = dto.Amount,
            OrderDate = DateTime.SpecifyKind(dto.OrderDate, DateTimeKind.Utc),
            CustomerId = dto.CustomerId
        };
        _orderRepo.Add(order);
        return true;
    }
    public bool Update(int id, OrderUpdateDTO dto)
    {
        var order = _orderRepo.GetById(id);
        if (order == null) return false;

        order.Amount = dto.Amount;
        order.OrderDate = DateTime.SpecifyKind(dto.OrderDate, DateTimeKind.Utc);
        _orderRepo.Update(order);
        return true;
    }
    public bool Patch(int id, OrderPatchDTO dto)
    {
        var order = _orderRepo.GetById(id);
        if (order == null) return false;

        if (dto.Amount.HasValue)
        {
            order.Amount = dto.Amount.Value;
        }
        if (dto.OrderDate.HasValue)
        {
            order.OrderDate = DateTime.SpecifyKind(dto.OrderDate.Value, DateTimeKind.Utc);
        }
        _orderRepo.Update(order);
        return true;
    }
    public bool Delete(int id)
    {
        var order = _orderRepo.GetById(id);
        if (order == null) return false;

        _orderRepo.Delete(order);
        return true;
    }

    public List<OrderResponseDTO>? GetOrdersByCustomerId(int customerId)
    {
        if (!_customerRepo.Exists(customerId))
            return null;
        var orders = _orderRepo.GetAll().Where(o => o.CustomerId == customerId)
        .Select(o => new OrderResponseDTO
        {
            OrderId = o.OrderId,
            Amount = o.Amount,
            OrderDate = o.OrderDate,
            CustomerId = customerId
        }).ToList();

        return orders;
    }
}

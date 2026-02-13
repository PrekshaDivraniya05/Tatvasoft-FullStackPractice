using System;

namespace CustomerOrder.Api.Entities;

public class Order
{
    public int OrderId { get; set; }

    public decimal Amount { get; set; }

    public DateTime OrderDate { get; set; }

    // Foreign Key
    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;
}

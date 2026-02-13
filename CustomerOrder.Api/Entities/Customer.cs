using System;

namespace CustomerOrder.Api.Entities;

public class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

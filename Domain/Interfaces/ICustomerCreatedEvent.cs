using System;

namespace Domain.Interfaces
{
    public interface ICustomerCreatedEvent
    {
        string CustomerId { get; }
        string Name { get; }
        DateTime Birthday { get; }
        string Type { get; }
        DateTime CreatedAt { get; }
    }
}

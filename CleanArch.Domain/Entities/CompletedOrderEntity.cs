using CleanArch.Domain.Entities.Common;


namespace CleanArch.Domain.Entities;

public class CompletedOrderEntity : BaseEntity
{
    public Guid OrderId { get; set; }

    public OrderEntity Order { get; set; }
}
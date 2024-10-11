using CleanArch.Domain.Entities.Common;


namespace CleanArch.Domain.Entities;

public class CompletedOrder : BaseEntity
{
    public Guid OrderId { get; set; }

    public Order Order { get; set; }
}
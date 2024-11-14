using CleanArch.Domain.Entities.Common;


namespace CleanArch.Domain.Entities;

public class OrderEntity : BaseEntity
{
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? OrderCode { get; set; }
    public BasketEntity? Basket { get; set; }
    public CompletedOrderEntity? CompletedOrder { get; set; }
}

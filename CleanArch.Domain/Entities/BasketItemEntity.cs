using CleanArch.Domain.Entities.Common;


namespace CleanArch.Domain.Entities;

public class BasketItemEntity : BaseEntity
{
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public BasketEntity? Basket { get; set; }
    public ProductEntity? Product { get; set; }
}

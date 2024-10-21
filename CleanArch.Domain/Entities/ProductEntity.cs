using CleanArch.Domain.Entities.Common;


namespace CleanArch.Domain.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<BasketItemEntity> BasketItems { get; set; }
}
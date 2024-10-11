using CleanArch.Domain.Entities.Common;


namespace CleanArch.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}
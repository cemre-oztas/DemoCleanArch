using CleanArch.Domain.Entities.Common;
using CleanArch.Domain.Entities.Identity;


namespace CleanArch.Domain.Entities;

public class BasketEntity : BaseEntity
{
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
    public OrderEntity? Order { get; set; }
    public ICollection<BasketItemEntity>? BasketItems { get; set; }
}

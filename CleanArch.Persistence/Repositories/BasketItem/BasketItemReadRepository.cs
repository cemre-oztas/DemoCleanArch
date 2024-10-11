using CleanArch.Application.Repositories.BasketItem;
using CleanArch.Persistence.Contexts;
using CleanArch.Domain.Entities;


namespace CleanArch.Persistence.Repositories.BasketItem;

public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
{
    public BasketItemReadRepository(APIDbContext context) : base(context)
    {
    }
}

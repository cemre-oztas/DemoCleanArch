using CleanArch.Application.Repositories.BasketItemEntityRepository;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.BasketItem;

public class BasketItemReadRepository : ReadRepository<BasketItemEntity>, IBasketItemEntityReadRepository
{
    public BasketItemReadRepository(APIDbContext context) : base(context)
    {
    }

    
}
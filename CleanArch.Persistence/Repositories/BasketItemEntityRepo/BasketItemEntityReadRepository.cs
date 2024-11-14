using CleanArch.Application.Repositories.BasketItemEntityRepository;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.BasketItemEntityRepo;

public class BasketItemEntityReadRepository : ReadRepository<BasketItemEntity>, IBasketItemEntityReadRepository
{
    public BasketItemEntityReadRepository(APIDbContext context) : base(context)
    {

    }
}


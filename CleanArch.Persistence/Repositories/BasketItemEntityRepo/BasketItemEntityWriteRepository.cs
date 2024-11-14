using CleanArch.Application.Repositories.BasketItemEntityRepository;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.BasketItemEntityRepo;

public class BasketItemEntityWriteRepository : WriteRepository<BasketItemEntity>, IBasketItemEntityWriteRepository
{
    public BasketItemEntityWriteRepository(APIDbContext context) : base(context)
    {

    }
}


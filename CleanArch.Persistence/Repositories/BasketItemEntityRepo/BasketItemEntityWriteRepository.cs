using CleanArch.Application.Repositories.BasketItemEntityRepository;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.BasketItem
{
    public class BasketItemEntityWriteRepository : WriteRepository<Domain.Entities.BasketItemEntity>, IBasketItemEntityWriteRepository
    {
        public BasketItemEntityWriteRepository(APIDbContext context) : base(context)
        {

        }
    }
}


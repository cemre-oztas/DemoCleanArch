using CleanArch.Application.Repositories.BasketItem;
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


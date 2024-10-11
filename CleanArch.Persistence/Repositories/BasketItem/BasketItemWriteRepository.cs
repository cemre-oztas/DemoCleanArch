using CleanArch.Application.Repositories.BasketItem;
using CleanArch.Persistence.Contexts;
using CleanArch.Domain.Entities;


namespace CleanArch.Persistence.Repositories.BasketItem;

public class BasketItemWriteRepository : WriteRepository<IBasketItemWriteRepository>, IBasketItemWriteRepository
{
    public BasketItemWriteRepository(APIDbContext context) : base(context)
    {
    }
}

using CleanArch.Application.Repositories.Basket;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.Basket;

public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
{
    public BasketReadRepository(APIDbContext context) : base(context)
    {
    }
}
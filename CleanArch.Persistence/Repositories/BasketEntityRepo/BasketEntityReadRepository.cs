using CleanArch.Application.Repositories.BasketEntityRepository;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.RepoBasket;

public class BasketEntityReadRepository : ReadRepository<BasketEntity>, IBasketEntityReadRepository
{
    public BasketEntityReadRepository(APIDbContext context) : base(context)
    {

    }
}

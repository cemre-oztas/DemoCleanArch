using CleanArch.Application.Repositories.BasketEntityRepository;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.RepoBasket;

public class BasketEntityWriteRepository : WriteRepository<BasketEntity>, IBasketEntityWriteRepository
{
    public BasketEntityWriteRepository(APIDbContext context) : base(context)
    {

    }
}

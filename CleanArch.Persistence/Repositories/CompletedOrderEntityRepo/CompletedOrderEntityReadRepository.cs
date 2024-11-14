using CleanArch.Application.Repositories.CompletedOrderEntityRepository;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.CompletedOrder;

public class CompletedOrderEntityReadRepository : ReadRepository<Domain.Entities.CompletedOrderEntity>, ICompletedOrderEntityReadRepository
{
    public CompletedOrderEntityReadRepository(APIDbContext context) : base(context)
    {

    }
}

using CleanArch.Application.Repositories.CompletedOrder;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.CompletedOrder;

public class CompletedOrderEntityReadRepository : ReadRepository<Domain.Entities.CompletedOrderEntity>, ICompletedOrderEntityReadRepository
{
    public CompletedOrderEntityReadRepository(APIDbContext context) : base(context)
    {
    }
}

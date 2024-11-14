using CleanArch.Application.Repositories.OrderEntityRepository;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;


namespace CleanArch.Persistence.Repositories.OrderEntityRepo;

public class OrderEntityWriteRepository : WriteRepository<OrderEntity>, IOrderEntityWriteRepository
{
    public OrderEntityWriteRepository(APIDbContext context) : base(context)
    {

    }
}

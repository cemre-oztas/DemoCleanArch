using CleanArch.Application.Repositories.Order;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;


namespace CleanArch.Persistence.Repositories.Order;

public class OrderEntityReadRepository : ReadRepository<OrderEntity>, IOrderEntityReadRepository
{
    public OrderEntityReadRepository(APIDbContext context) : base(context)
    {

    }
}

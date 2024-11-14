using CleanArch.Application.Repositories.Product;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;


namespace CleanArch.Persistence.Repositories.ProductEntityRepo;

public class ProductEntityReadRepository : ReadRepository<ProductEntity>, IProductEntityReadRepository
{
    public ProductEntityReadRepository(APIDbContext context) : base(context)
    {

    }
}

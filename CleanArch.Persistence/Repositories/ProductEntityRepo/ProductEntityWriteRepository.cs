using CleanArch.Application.Repositories.Product;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;


namespace CleanArch.Persistence.Repositories.ProductEntityRepo;

public class ProductEntityWriteRepository : WriteRepository<ProductEntity>, IProductEntityWriteRepository
{
    public ProductEntityWriteRepository(APIDbContext context) : base(context)
    {

    }
}

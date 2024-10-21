using CleanArch.Application.Repositories.Product;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;
using CleanArch.Persistence.Repositories;


namespace CleanArch.Persistence.Repositories.Product;

public class ProductEntityWriteRepository : WriteRepository<ProductEntity>, IProductEntityWriteRepository
{
    public ProductEntityWriteRepository(APIDbContext context) : base(context)
    {

    }
}

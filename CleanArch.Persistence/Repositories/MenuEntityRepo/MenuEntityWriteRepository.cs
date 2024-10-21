using CleanArch.Application.Repositories.Menu;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;


namespace CleanArch.Persistence.Repositories.Menu;

public class MenuEntityWriteRepository : WriteRepository<MenuEntity>, IMenuEntityWriteRepository
{
    public MenuEntityWriteRepository(APIDbContext context) : base(context)
    {
    }
}
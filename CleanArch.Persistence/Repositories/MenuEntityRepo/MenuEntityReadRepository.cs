﻿using CleanArch.Application.Repositories.Menu;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories.Menu;

public class MenuEntityReadRepository : ReadRepository<Domain.Entities.MenuEntity>, IMenuEntityReadRepository
{
    public MenuEntityReadRepository(APIDbContext context) : base(context)
    {
    }
}
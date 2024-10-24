﻿using CleanArch.Application.Repositories.OrderEntityRepository;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;


namespace CleanArch.Persistence.Repositories.Order;

public class OrderEntityWriteRepository : WriteRepository<OrderEntity>, IOrderEntityWriteRepository
{
    public OrderEntityWriteRepository(APIDbContext context) : base(context)
    {

    }
}

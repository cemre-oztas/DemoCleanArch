﻿using CleanArch.Application.Repositories.Product;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    readonly IProductEntityReadRepository _productReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;
    public GetAllProductQueryHandler(IProductEntityReadRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger)
    {
        _productReadRepository = productReadRepository;
        _logger = logger;
    }
    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all products");

        var totalProductCount = _productReadRepository.GetAll(false).Count();

        var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
            .Include(p => p.ProductImageFiles)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
                p.ProductImageFiles
            }).ToList();

        return new()
        {
            Products = products,
            TotalProductCount = totalProductCount
        };
    }
}
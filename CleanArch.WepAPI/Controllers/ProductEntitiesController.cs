using CleanArch.Application.Abstractions.Services;
using CleanArch.Application.Features.Commands.ProductEntity.CreateProductEntity;
using CleanArch.Application.Features.Commands.ProductEntity.RemoveProductEntity;
using CleanArch.Application.Features.Commands.ProductEntity.UpdateProductEntity;
using CleanArch.Application.Features.Queries.ProductEntityQueries.GetAllProductEntity;
using CleanArch.Application.Features.Queries.ProductEntityQueries.GetByIdProductEntity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace CleanArch.WepAPI.Controllers; 


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    readonly IMediator _mediator;
    readonly ILogger<ProductsController> _logger;
    readonly IProductEntityService _productService;

    public ProductsController
        (IMediator mediator, IProductEntityService productService)
    {
        _mediator = mediator;
        _productService = productService;
    }

    [HttpGet]
    [Authorize(Policy = "Product.Read")]
    public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
    {
        GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
        return Ok(response);
    }


    [HttpGet("{Id}")]
    [Authorize(Policy = "Product.Read")]
    public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
    {
        GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
        return Ok(response);
    }

    [HttpPost]
    [Authorize(Policy = "Product.Write")]
    public async Task<IActionResult> Post(CreateProductEntityCommandRequest createProductCommandRequest)
    {
        CreateProductEntityCommandResponse response = await _mediator.Send(createProductCommandRequest);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    [Authorize(Policy = "Product.Update")]
    public async Task<IActionResult> Put([FromBody] UpdateProductEntityCommandRequest updateProductCommandRequest)
    {
        UpdateProductEntityCommandResponse response = await _mediator.Send(updateProductCommandRequest);
        return Ok();
    }

    [HttpDelete("{Id}")]
    [Authorize(Policy = "Product.Delete")]
    public async Task<IActionResult> Delete([FromRoute] RemoveProductEntityCommandRequest removeProductCommandRequest)
    {
        RemoveProductEntityCommandResponse response = await _mediator.Send(removeProductCommandRequest);
        return Ok();
    }


}

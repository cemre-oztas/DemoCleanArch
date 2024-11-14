using CleanArch.Application.Features.Commands.OrderEntityCommand.CompleteOrderEntity;
using CleanArch.Application.Features.Commands.OrderEntityCommand.CreateOrderEntity;
using CleanArch.Application.Features.Queries.OrderEntityQueries.GetAllOrders;
using CleanArch.Application.Features.Queries.OrderEntityQueries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CleanArch.WepAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class OrdersController : ControllerBase
{
    readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    [Authorize(Policy = "Order.Read")]
    public async Task<ActionResult> GetOrderById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
    {
        GetOrderByIdQueryResponse response = await _mediator.Send(getOrderByIdQueryRequest);
        return Ok(response);
    }

    [HttpGet]
    [Authorize(Policy = "Order.Read")]
    public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
    {
        GetAllOrdersQueryResponse response = await _mediator.Send(getAllOrdersQueryRequest);
        return Ok(response);
    }

    [HttpPost]
    [Authorize(Policy = "Order.Write")]
    public async Task<ActionResult> CreateOrder(CreateOrderEntityCommandRequest createOrderCommandRequest)
    {
        CreateOrderEntityCommandResponse response = await _mediator.Send(createOrderCommandRequest);
        return Ok(response);
    }

    [HttpPut("complete-order/{Id}")]
    [Authorize(Policy = "Order.Update")]
    public async Task<ActionResult> CompleteOrder([FromRoute] CompleteOrderEntityCommandRequest completeOrderCommandRequest)
    {
        CompleteOrderEntityCommandResponse response = await _mediator.Send(completeOrderCommandRequest);
        return Ok(response);
    }
}

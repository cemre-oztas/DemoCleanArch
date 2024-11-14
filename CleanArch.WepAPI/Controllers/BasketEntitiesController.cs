using CleanArch.Application.Features.Commands.BasketEntityCommand.AddItemToBasketEntity;
using CleanArch.Application.Features.Commands.BasketEntityCommand.RemoveBasketItem;
using CleanArch.Application.Features.Commands.BasketEntityCommand.UpdateQuantity;
using CleanArch.Application.Features.Queries.BasketEnitityQueries.GetBasketEntityItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WepAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class BasketEntitiesController : ControllerBase
{
    readonly IMediator _mediator;

    public BasketEntitiesController (IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Policy = "Basket.Read")]
    public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest getBasketItemsQueryRequest)
    {
        List<GetBasketItemsQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
        return Ok(response);
    }

    [HttpPost]
    [Authorize(Policy = "Basket.Write")]
    public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
    {
        AddItemToBasketEntityCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
        return Ok(response);
    }

    [HttpPut]
    [Authorize(Policy = "Basket.Update")]
    public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
    {
        UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
        return Ok(response);
    }

    [HttpDelete("{BasketItemId}")]
    [Authorize(Policy = "Basket.Delete")]
    public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemEntityCommandRequest removeBasketItemCommandRequest)
    {
        RemoveBasketItemEntityCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
        return Ok(response);
    }
}

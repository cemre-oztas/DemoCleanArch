using CleanArch.Application.Abstractions.Services;
using CleanArch.Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WepAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    readonly IMediator _mediator;
    readonly IMailService _mailService;

    public UsersController(IMediator mediator, IMailService mailService)
    {
        _mediator = mediator;
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUser createUser)
    {
        CreateUser response = (CreateUser)await _mediator.Send(createUser);
        return Ok(response);
    }

}

using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using TaskManagementSystem.Application.Features.User.DTO;
using TaskManagementSystem.Application.Features.User.CQRS.Requests;
using TaskManagementSystem.Application.Models.Identity;

namespace TaskManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<Application.Features.User.DTO.LoginResponse>> Login([FromBody] LoginDto Login)
    {
        var response =  await _mediator.Send(new LoginRequest{LoginDto = Login});
        return Ok(response);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegisterDto register)
    {
        var response =  await _mediator.Send(new RegisterCommand{RegisterDto = register});
        return Ok(response);
    }

}
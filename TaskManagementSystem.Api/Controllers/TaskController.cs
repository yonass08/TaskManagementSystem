using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;
using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Queries;
using TaskManagementSystem.Application.Features.Task.DTO;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;
    public TaskController(IMediator mediatR)
    {
        _mediator = mediatR;     
    }

    
    [HttpGet]
    public async Task<ActionResult<List<GetTaskListDto>>> Get()
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = 1;
        var Query = new GetTaskListQuery()
        {
            UserId = userId
        };

        var Tasks = await _mediator.Send(Query);
        return Ok(Tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetTaskDetailDto>> Get(int id)
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = 1;

        var Query = new GetTaskDetailQuery()
        {
            UserId = userId,
            Id = id
        };

        var Task = await _mediator.Send(Query);
        return Ok(Task);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateTaskDto TaskDto)
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = 1;
            
        var Command = new CreateTaskCommand()
        {
            TaskDto = TaskDto,
            UserId = userId
        };
        
        var response = await _mediator.Send(Command);
        return Ok(response);   
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateTaskDto TaskDto)
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // if (userId == null)
        //     throw new BadRequestException($"missing {userId}");
        var userId = 1;
        
        var Command = new UpdateTaskCommand()
        {
            updateTaskDto = TaskDto,
            UserId = userId
        };
        
        var response = await _mediator.Send(Command);
        return NoContent(); 
    }

    [HttpPut("Status")]
    public async Task<ActionResult> Put(int id,  string status)
    {
        

        var userId = 1;
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // if (userId == null)
        //     throw new BadRequestException($"missing {userId}");

        var Command = new UpdateTaskStatusCommand()
        {
            updateTaskStatusDto = new UpdateTaskStatusDto()
            {
                Id = id,
                Status = (Status)Enum.Parse(typeof(Status), status)
            },
            UserId = userId
        };
        
        var response = await _mediator.Send(Command);
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = 1;

        var Command = new DeleteTaskCommand()
        {
            UserId = userId,
            TaskId = id
        };
        
        var response = await _mediator.Send(Command);
        return NoContent(); 
    }
}


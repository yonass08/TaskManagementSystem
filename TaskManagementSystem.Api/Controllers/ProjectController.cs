using TaskManagementSystem.Application.Features.Project.CQRS.Requests.Commands;
using TaskManagementSystem.Application.Features.Project.CQRS.Requests.Queries;
using TaskManagementSystem.Application.Features.Project.DTO;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.API.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProjectController(IMediator mediatR)
    {
        _mediator = mediatR;     
    }

    
    [HttpGet]
    public async Task<ActionResult<List<GetProjectListDto>>> Get()
    {

            
        var Query = new GetProjectListQuery();
        var Projects = await _mediator.Send(Query);
        return Ok(Projects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProjectDetailDto>> Get(int id)
    {
        var userId = 1;

        var Query = new GetProjectDetailQuery()
        {
            ProjectId = id,
            UserId = userId
        };

        var Project = await _mediator.Send(Query);
        return Ok(Project);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateProjectDto ProjectDto)
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = 1;


        var Command = new CreateProjectCommand()
        {
            UserId = userId,
            createProjectDto = ProjectDto
        };

        var response = await _mediator.Send(Command);
        return Ok(response);   
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateProjectDto ProjectDto)
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = 1;
        var Command = new UpdateProjectCommand()
        {
            UserId = userId,
            updateProjectDto = ProjectDto
        };

        var response = await _mediator.Send(Command);
        return NoContent(); 
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userId = 1;


        var Command = new DeleteProjectCommand()
        {
            OwnerId = userId,
            ProjectId = id
        };

        var response = await _mediator.Send(Command);
        return NoContent(); 
    }
}


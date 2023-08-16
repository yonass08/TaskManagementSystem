using MediatR;
using TaskManagementSystem.Application.Features.Project.DTO;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Requests.Commands;

public class UpdateProjectCommand : IRequest
{
    public UpdateProjectDto updateProjectDto { get; set; }

    public int UserId { get; set; }

}

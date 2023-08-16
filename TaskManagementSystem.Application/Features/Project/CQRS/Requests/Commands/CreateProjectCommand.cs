using MediatR;
using TaskManagementSystem.Application.Features.Project.DTO;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Requests.Commands;

public class CreateProjectCommand : IRequest<int>
{
    public CreateProjectDto createProjectDto { get; set; }

    public int UserId { get; set; }
}

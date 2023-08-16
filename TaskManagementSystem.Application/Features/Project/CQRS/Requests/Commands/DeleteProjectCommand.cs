using MediatR;
using TaskManagementSystem.Application.Features.Project.DTO;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Requests.Commands;

public class DeleteProjectCommand : IRequest
{
    public int ProjectId { get; set; }

    public int OwnerId { get; set; }

}

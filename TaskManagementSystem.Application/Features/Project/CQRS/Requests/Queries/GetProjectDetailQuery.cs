using MediatR;
using TaskManagementSystem.Application.Features.Project.DTO;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Requests.Queries;

public class GetProjectDetailQuery : IRequest<GetProjectDetailDto>
{
    public int ProjectId { get; set; }

    public int UserId { get; set; }

}

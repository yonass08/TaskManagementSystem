using MediatR;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Requests.Queries;

public class GetTaskDetailQuery : IRequest<GetTaskDetailDto>
{
    public int Id { get; set; }

    public int UserId { get; set; }

}

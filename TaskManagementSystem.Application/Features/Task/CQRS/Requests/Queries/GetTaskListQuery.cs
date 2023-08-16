using MediatR;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Requests.Queries;

public class GetTaskListQuery : IRequest<List<GetTaskListDto>>
{
    public int UserId { get; set; }

}

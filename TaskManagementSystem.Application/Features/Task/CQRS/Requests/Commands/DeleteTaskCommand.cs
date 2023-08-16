using MediatR;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;

public class DeleteTaskCommand : IRequest
{
    public int TaskId { get; set; }

    public int UserId { get; set; }

}

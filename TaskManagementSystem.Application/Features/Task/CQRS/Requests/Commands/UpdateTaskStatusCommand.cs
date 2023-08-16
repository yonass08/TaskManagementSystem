using MediatR;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;

public class UpdateTaskStatusCommand : IRequest
{
    public UpdateTaskStatusDto updateTaskStatusDto { get; set; }

    public int UserId { get; set; }

}

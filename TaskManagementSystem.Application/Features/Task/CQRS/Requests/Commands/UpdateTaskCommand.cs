using MediatR;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;

public class UpdateTaskCommand : IRequest
{
    public UpdateTaskDto updateTaskDto { get; set; }

    public int UserId { get; set; }

}

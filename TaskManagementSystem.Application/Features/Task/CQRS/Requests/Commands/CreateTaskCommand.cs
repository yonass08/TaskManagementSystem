using MediatR;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;

public class CreateTaskCommand : IRequest<int>
{
    public CreateTaskDto TaskDto { get; set; }
    public int UserId { get; set; }

}

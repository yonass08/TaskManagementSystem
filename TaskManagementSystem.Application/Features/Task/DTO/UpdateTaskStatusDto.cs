using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Task.DTO;

public class UpdateTaskStatusDto
{
    public int Id { get; set; }

    public Status Status { get; set; }

}

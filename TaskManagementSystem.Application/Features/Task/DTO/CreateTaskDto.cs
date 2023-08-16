using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Task.DTO;

public class CreateTaskDto : BaseTaskDto
{
    public int UserId { get; set; }

}
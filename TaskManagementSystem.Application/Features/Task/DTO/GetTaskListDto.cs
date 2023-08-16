using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Task.DTO;

public class GetTaskListDto : BaseTaskDto
{
    public int UserId { get; set; }

    public Status Status { get; set; }

}

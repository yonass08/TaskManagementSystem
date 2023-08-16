using TaskManagementSystem.Application.Features.Project.DTO;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Task.DTO;

public class GetTaskDetailDto : BaseTaskDto
{
    public int UserId { get; set; }

    public GetProjectListDto Project { get; set; }

    public Status Status { get; set; }

}

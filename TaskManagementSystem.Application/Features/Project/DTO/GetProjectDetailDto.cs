using TaskManagementSystem.Application.Features.Task.DTO;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Project.DTO;

public class GetProjectDetailDto : BaseProjectDto
{
    public int ProjectId {get; set;}
    public int OwnerId {get; set;}

    public  List<GetTaskListDto> Tasks { get; set; }


}

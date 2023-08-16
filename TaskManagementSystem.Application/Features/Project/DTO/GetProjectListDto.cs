using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Project.DTO;

public class GetProjectListDto : BaseProjectDto
{
    public int OwnerId { get; set; }

    public int ProjectId {get; set;}


}

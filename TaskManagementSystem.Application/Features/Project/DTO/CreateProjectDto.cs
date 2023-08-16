using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Project.DTO;

public class CreateProjectDto : BaseProjectDto
{
    public int OwnerId {get; set;}
}

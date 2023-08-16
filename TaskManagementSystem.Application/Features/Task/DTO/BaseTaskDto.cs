using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Features.Task.DTO;

public abstract class BaseTaskDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

}

using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.Features.Project.DTO.Validators;


public class CreateProjectDtoValidator : BaseProjectDtoValidator<CreateProjectDto>
{
    private readonly ITaskRepository _TaskRepository;

    public CreateProjectDtoValidator(ITaskRepository TaskRepository)
    {
        _TaskRepository = TaskRepository;

    }

    private async Task<bool> TaskExists(int userId, CancellationToken cancellationToken)
    {
        return await _TaskRepository.Exists(userId);
    }
}


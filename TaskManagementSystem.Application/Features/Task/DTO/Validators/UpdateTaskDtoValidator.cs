using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.Features.Task.DTO.Validators;

public class UpdateTaskDtoValidator : BaseTaskValidator<UpdateTaskDto>
{
    private ITaskRepository _TaskRepository;

    public UpdateTaskDtoValidator(ITaskRepository TaskRepository)
    {
        _TaskRepository = TaskRepository;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .MustAsync(TaskExists).WithMessage("User task does not exist.");
    }

    private async Task<bool> TaskExists(int id, CancellationToken cancellationToken)
    {
        return await _TaskRepository.Exists(id);
    }
}

using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.Features.Project.DTO.Validators;

public class UpdateProjectDtoValidator : BaseProjectDtoValidator<UpdateProjectDto>
{
    private IProjectRepository _ProjectRepository;

    public UpdateProjectDtoValidator(IProjectRepository ProjectRepository)
    {
        _ProjectRepository = ProjectRepository;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .MustAsync(ProjectExists).WithMessage("User task does not exist.");
    }

    private async Task<bool> ProjectExists(int id, CancellationToken cancellationToken)
    {
        return await _ProjectRepository.Exists(id);
    }
}
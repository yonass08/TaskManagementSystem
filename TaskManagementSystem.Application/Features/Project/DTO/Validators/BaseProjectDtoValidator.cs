using FluentValidation;

namespace TaskManagementSystem.Application.Features.Project.DTO.Validators;

public class BaseProjectDtoValidator<T> : AbstractValidator<T> where T : BaseProjectDto
{
    public BaseProjectDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
    }
}


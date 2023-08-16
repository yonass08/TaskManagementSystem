using FluentValidation;

namespace TaskManagementSystem.Application.Features.Task.DTO.Validators;

public class BaseTaskValidator<T> : AbstractValidator<T> where T : BaseTaskDto
{
    public BaseTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty");

    }
}


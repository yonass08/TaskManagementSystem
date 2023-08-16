using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.Features.Task.DTO.Validators;

public class CreateTaskDtoValidator : BaseTaskValidator<CreateTaskDto>
{
    private readonly IUserRepository _userRepository;

    public CreateTaskDtoValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.UserId)
            .MustAsync(UserExists).WithMessage("User does not exist.");
    }

    private async Task<bool> UserExists(int UserId, CancellationToken cancellationToken)
    {
        return await _userRepository.Exists(UserId);
    }
}


using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;
using TaskManagementSystem.Application.Features.Task.DTO.Validators;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Handlers.Commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        if (request.UserId != request.TaskDto.UserId)
            throw new UnauthorizedException($"can't creat not mach");

        var validator = new CreateTaskDtoValidator(_unitOfWork.UserRepository);
        var validationResult = await validator.ValidateAsync(request.TaskDto);


        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var Task = _mapper.Map<Domain.Task>(request.TaskDto);

        Task = await _unitOfWork.TaskRepository.Add(Task);
        if (await _unitOfWork.Save() < 0)
            throw new ActionNotPerfomedException("user not created");

        return Task.Id;

    }
}


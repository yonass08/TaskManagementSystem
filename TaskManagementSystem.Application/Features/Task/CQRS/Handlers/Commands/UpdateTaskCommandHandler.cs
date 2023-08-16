using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;
using TaskManagementSystem.Application.Features.Task.DTO.Validators;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Handlers.Commands;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IUnitOfWork UnitOfWork => _unitOfWork;

    public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {

        var validator = new UpdateTaskDtoValidator(UnitOfWork.TaskRepository);
        var validationResult = await validator.ValidateAsync(request.updateTaskDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var Task = await UnitOfWork.TaskRepository.Get(request.updateTaskDto.Id);

        if (Task.UserId != request.UserId)
            throw new UnauthorizedException($"ac = {Task.UserId} and {request.UserId}");

        _mapper.Map(request.updateTaskDto, Task);
        await UnitOfWork.TaskRepository.Update(Task);

        if (await UnitOfWork.Save() < 0)
            throw new ActionNotPerfomedException("Task not Updated");

        return Unit.Value;

    }
}
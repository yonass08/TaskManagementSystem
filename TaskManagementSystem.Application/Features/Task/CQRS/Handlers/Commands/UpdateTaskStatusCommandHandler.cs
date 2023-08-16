using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;
using TaskManagementSystem.Application.Features.Task.DTO.Validators;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Handlers.Commands;

public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public UpdateTaskStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public IUnitOfWork UnitOfWork => _unitOfWork;

    public async Task<Unit> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {

        var validator = new UpdateTaskStatusDtoValidator(UnitOfWork.TaskRepository);
        var validationResult = await validator.ValidateAsync(request.updateTaskStatusDto);


        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var Task = await UnitOfWork.TaskRepository.Get(request.updateTaskStatusDto.Id);

        if (Task.UserId != request.UserId)
            throw new UnauthorizedException($"ac = {Task.UserId} and {request.UserId}");

        await UnitOfWork.TaskRepository.UpdateStatus(Task, request.updateTaskStatusDto.Status);

        if (await UnitOfWork.Save() < 0)
            throw new ActionNotPerfomedException("TaskStatus not Updated");

        return Unit.Value;

    }
}
using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Commands;
using TaskManagementSystem.Application.Features.Task.DTO.Validators;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Handlers.Commands;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public DeleteTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var Task = await _unitOfWork.TaskRepository.Get(request.TaskId);
        if(Task == null)
            throw new NotFoundException("Task", nameof(Task));

        if (Task.UserId != request.UserId)
            throw new UnauthorizedException($"ac = {Task.UserId} and {request.UserId}");

        await _unitOfWork.TaskRepository.Delete(Task);

        if (await _unitOfWork.Save() < 0)
            throw new ActionNotPerfomedException("Task not Deleted");

        return Unit.Value;

    }
}
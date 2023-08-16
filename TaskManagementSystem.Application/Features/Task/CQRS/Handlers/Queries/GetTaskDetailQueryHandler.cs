using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Queries;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Handlers.Queries;


public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, GetTaskDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTaskDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetTaskDetailDto> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
    {
        var Exists = await _unitOfWork.TaskRepository.Exists(request.Id);
        if (Exists == false)
            throw new NotFoundException(nameof(Domain.Task), request.Id);

        var Task = await _unitOfWork.TaskRepository.GetWithDetails(request.Id);

        if (Task.UserId != request.Id)
            throw new UnauthorizedException($"ac = {Task.UserId} and {request.UserId}");

        var TaskDto = _mapper.Map<GetTaskDetailDto>(Task);
        return TaskDto;
    }
}
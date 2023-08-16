
using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.CQRS.Requests.Queries;
using TaskManagementSystem.Application.Features.Task.DTO;

namespace TaskManagementSystem.Application.Features.Task.CQRS.Handlers.Queries;

public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, List<GetTaskListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetTaskListDto>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        var Tasks = await _unitOfWork.TaskRepository.GetAll();
        var TaskDtos = _mapper.Map<List<GetTaskListDto>>(Tasks);

        var UserId = request.UserId;
        return TaskDtos.Where(u => u.UserId == UserId).ToList();
    }
}




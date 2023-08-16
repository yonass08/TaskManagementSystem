using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Project.CQRS.Requests.Queries;
using TaskManagementSystem.Application.Features.Project.DTO;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Handlers.Queries;


public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, GetProjectDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetProjectDetailDto> Handle(GetProjectDetailQuery request, CancellationToken cancellationToken)
    {
        var Exists = await _unitOfWork.ProjectRepository.Exists(request.ProjectId);
        if (Exists == false)
            throw new NotFoundException(nameof(Domain.Project), request.ProjectId);

        var Project = await _unitOfWork.ProjectRepository.GetWithDetails(request.ProjectId);

        var ProjectDto = _mapper.Map<GetProjectDetailDto>(Project);
        return ProjectDto;
    }
}
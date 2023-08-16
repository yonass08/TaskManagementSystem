
using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Project.CQRS.Requests.Queries;
using TaskManagementSystem.Application.Features.Project.DTO;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Handlers.Queries;

public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, List<GetProjectListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public GetProjectListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<List<GetProjectListDto>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
    {

        var Projects = await _unitOfWork.ProjectRepository.GetAll();
        var ProjectDtos = _mapper.Map<List<GetProjectListDto>>(Projects);


        return ProjectDtos;
    }
}




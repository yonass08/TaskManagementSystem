using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Project.CQRS.Requests.Commands;
using TaskManagementSystem.Application.Features.Project.DTO.Validators;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Handlers.Commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {

        var validator = new CreateProjectDtoValidator(_unitOfWork.TaskRepository);
        var validationResult = await validator.ValidateAsync(request.createProjectDto);


        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var Project = _mapper.Map<Domain.Project>(request.createProjectDto);

        Project = await _unitOfWork.ProjectRepository.Add(Project);
        if (await _unitOfWork.Save() < 0)
            throw new ActionNotPerfomedException("Project not created");

        return Project.Id;

    }
}


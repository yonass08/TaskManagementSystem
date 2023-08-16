using MediatR;
using TaskManagementSystem.Application.Features.Project.DTO;

namespace TaskManagementSystem.Application.Features.Project.CQRS.Requests.Queries;

public class GetProjectListQuery : IRequest<List<GetProjectListDto>>
{

}

using AutoMapper;
using TaskManagementSystem.Application.Features.Project.DTO;
using TaskManagementSystem.Application.Features.Task.DTO;
using TaskManagementSystem.Domain;
using TaskManagementSystem.Application.Models.Identity;

namespace TaskManagementSystem.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        #region  Task
        CreateMap<System.Threading.Tasks.Task, CreateTaskDto>().ReverseMap();
        CreateMap<System.Threading.Tasks.Task, UpdateTaskDto>().ReverseMap();
        CreateMap<System.Threading.Tasks.Task, GetTaskListDto>().ReverseMap();
        CreateMap<System.Threading.Tasks.Task, GetTaskDetailDto>().ReverseMap();
        #endregion

        #region  Project
        CreateMap<Project, CreateProjectDto>().ReverseMap();
        CreateMap<Project, UpdateProjectDto>().ReverseMap();
        CreateMap<Project, GetProjectListDto>().ReverseMap();
        CreateMap<Project, GetProjectDetailDto>().ReverseMap();
        #endregion

    }
}

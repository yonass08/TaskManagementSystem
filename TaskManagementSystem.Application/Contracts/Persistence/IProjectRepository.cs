using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Contracts.Persistence;

public interface IProjectRepository : IGenericRepository<Project>
{

    Task<Project> GetWithDetails(int id);


}

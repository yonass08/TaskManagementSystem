using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Persistence.Repositories;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{

    private readonly TaskManagementSystemDbContext _dbContext;
    public ProjectRepository(TaskManagementSystemDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task<Project> GetWithDetails(int id)
    {
        return await _dbContext.Projects.Include(c => c.Tasks).FirstOrDefaultAsync(c => c.Id == id);
    }

}

using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Persistence.Repositories;

public class TaskRepository : GenericRepository<Domain.Task>, ITaskRepository
{

    private readonly TaskManagementSystemDbContext _dbContext;
    public TaskRepository(TaskManagementSystemDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async System.Threading.Tasks.Task<Domain.Task> GetWithDetails(int id)
    {
        return await _dbContext.Tasks
            .Include(u => u.Project)
            .FirstOrDefaultAsync(u => u.Id == id);

    }

    public System.Threading.Tasks.Task UpdateStatus(Domain.Task Task, Status status)
    {
        Task.Status = status;
        _dbContext.Entry(Task).State = EntityState.Modified;
        return _dbContext.SaveChangesAsync();
    }
}

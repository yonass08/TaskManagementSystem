using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Contracts.Persistence;

public interface ITaskRepository : IGenericRepository<Domain.Task>
{
    System.Threading.Tasks.Task UpdateStatus(Domain.Task Task, Status status);

    System.Threading.Tasks.Task<Domain.Task> GetWithDetails(int id);


}

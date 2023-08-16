namespace TaskManagementSystem.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{

    ITaskRepository TaskRepository { get; }

    IProjectRepository ProjectRepository { get; }

    IUserRepository UserRepository { get; }

    Task<int> Save();

}

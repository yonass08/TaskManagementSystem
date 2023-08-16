using TaskManagementSystem.Application.Contracts.Persistence;
namespace TaskManagementSystem.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly TaskManagementSystemDbContext _context;

    private ITaskRepository _TaskRepository;
    private IProjectRepository _ProjectRepository;
    private IUserRepository _UserRepository;


    public UnitOfWork(TaskManagementSystemDbContext context)
    {
        _context = context;
    }



    ITaskRepository IUnitOfWork.TaskRepository
    {
        get
        {
            if (_TaskRepository == null)
                _TaskRepository = new TaskRepository(_context);
            return _TaskRepository;
        }
    }

    IProjectRepository IUnitOfWork.ProjectRepository
    {
        get
        {
            if (_ProjectRepository == null)
                _ProjectRepository = new ProjectRepository(_context);
            return _ProjectRepository;
        }
    }

    IUserRepository IUnitOfWork.UserRepository
    {
        get
        {
            if (_UserRepository == null)
                _UserRepository = new UserRepository(_context);
            return _UserRepository;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
}


using TaskFlowPro.Application.Interfaces;
using TaskFlowPro.Domain.Entities;
using TaskFlowPro.Infrastructure.Persistence.Repositories;

namespace TaskFlowPro.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    
    // Lazy initialized repositories
    private IRepository<TaskItem>? _taskItems;
    private IRepository<Project>? _projects;
    private IRepository<User>? _users;
    private IRepository<ActivityLog>? _activityLogs;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IRepository<TaskItem> TaskItems => _taskItems ??= new Repository<TaskItem>(_dbContext);
    public IRepository<Project> Projects => _projects ??= new Repository<Project>(_dbContext);
    public IRepository<User> Users => _users ??= new Repository<User>(_dbContext);
    public IRepository<ActivityLog> ActivityLogs => _activityLogs ??= new Repository<ActivityLog>(_dbContext);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}

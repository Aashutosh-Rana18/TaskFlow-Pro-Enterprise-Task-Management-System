using TaskFlowPro.Domain.Entities;

namespace TaskFlowPro.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TaskItem> TaskItems { get; }
    IRepository<Project> Projects { get; }
    IRepository<User> Users { get; }
    IRepository<ActivityLog> ActivityLogs { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

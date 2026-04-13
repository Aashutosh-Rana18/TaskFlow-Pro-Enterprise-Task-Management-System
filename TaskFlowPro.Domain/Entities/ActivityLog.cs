using TaskFlowPro.Domain.Common;

namespace TaskFlowPro.Domain.Entities;

public class ActivityLog : BaseEntity
{
    public string Action { get; set; } = string.Empty; // e.g., "Created Task", "Updated Status"
    public string EntityType { get; set; } = string.Empty; // e.g., "TaskItem"
    public Guid EntityId { get; set; }
    public string Details { get; set; } = string.Empty; // JSON or text details of changes

    // Relationships
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}

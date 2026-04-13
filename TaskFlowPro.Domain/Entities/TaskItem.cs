using TaskFlowPro.Domain.Common;
using TaskFlowPro.Domain.Enums;

namespace TaskFlowPro.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    // Relationships
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public Guid? AssignedUserId { get; set; }
    public User? AssignedUser { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}

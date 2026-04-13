using TaskFlowPro.Domain.Common;

namespace TaskFlowPro.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    // Relationships
    public Guid TaskItemId { get; set; }
    public TaskItem TaskItem { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}

using TaskFlowPro.Domain.Common;

namespace TaskFlowPro.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? TargetCompletionDate { get; set; }
    
    // Ownership
    public Guid OwnerId { get; set; }
    public User Owner { get; set; } = null!;

    // Navigation properties
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}

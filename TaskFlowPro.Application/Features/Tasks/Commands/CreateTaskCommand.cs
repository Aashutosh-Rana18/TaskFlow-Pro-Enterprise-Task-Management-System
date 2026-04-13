using MediatR;
using TaskFlowPro.Domain.Enums;

namespace TaskFlowPro.Application.Features.Tasks.Commands;

public class CreateTaskCommand : IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public Guid ProjectId { get; set; }
    public Guid? AssignedUserId { get; set; }
}

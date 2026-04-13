using MediatR;
using TaskFlowPro.Application.Interfaces;
using TaskFlowPro.Domain.Entities;
using TaskFlowPro.Domain.Enums;

namespace TaskFlowPro.Application.Features.Tasks.Commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority,
            ProjectId = request.ProjectId,
            AssignedUserId = request.AssignedUserId,
            Status = TaskItemStatus.ToDo
        };

        await _unitOfWork.TaskItems.AddAsync(task, cancellationToken);
        
        // Example: Add Activity Log
        var log = new ActivityLog
        {
            Action = "Created Task",
            EntityType = "TaskItem",
            EntityId = task.Id,
            Details = $"Task '{task.Title}' created.",
            UserId = Guid.Empty // Ideally fetched from ICurrentUserService
        };
        await _unitOfWork.ActivityLogs.AddAsync(log, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}

using MediatR;
using TaskFlowPro.Application.DTOs;

namespace TaskFlowPro.Application.Features.Tasks.Queries;

public class GetTasksQuery : IRequest<IReadOnlyList<TaskDto>>
{
    public Guid ProjectId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

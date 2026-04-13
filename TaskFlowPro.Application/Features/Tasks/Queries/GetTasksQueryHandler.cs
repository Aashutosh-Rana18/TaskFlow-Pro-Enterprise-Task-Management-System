using AutoMapper;
using MediatR;
using TaskFlowPro.Application.DTOs;
using TaskFlowPro.Application.Interfaces;

namespace TaskFlowPro.Application.Features.Tasks.Queries;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IReadOnlyList<TaskDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        // Simple manual paging logic for query demonstration
        var allTasks = await _unitOfWork.TaskItems.FindAsync(t => t.ProjectId == request.ProjectId && !t.IsDeleted, cancellationToken);
        var pagedTasks = allTasks
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
            
        return _mapper.Map<IReadOnlyList<TaskDto>>(pagedTasks);
    }
}

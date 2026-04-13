using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.Application.Features.Tasks.Commands;
using TaskFlowPro.Application.Features.Tasks.Queries;

namespace TaskFlowPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
    {
        var taskId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTasks), new { id = taskId }, new { TaskId = taskId });
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetTasks(Guid projectId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetTasksQuery { ProjectId = projectId, PageNumber = pageNumber, PageSize = pageSize };
        var tasks = await _mediator.Send(query);
        return Ok(tasks);
    }
}

using FluentValidation;

namespace TaskFlowPro.Application.Features.Tasks.Commands;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(150)
            .NotEmpty();

        RuleFor(v => v.ProjectId)
            .NotEmpty().WithMessage("Project must be specified.");
            
        RuleFor(v => v.DueDate)
            .GreaterThan(DateTime.UtcNow).When(v => v.DueDate.HasValue)
            .WithMessage("Due date must be in the future.");
    }
}

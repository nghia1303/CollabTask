using FluentValidation;

namespace CollabTask.Application;

public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
{
    public CreateTaskDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(100).WithMessage("Title must not excess 100 characters.");

        RuleFor(x => x.ProjectId).NotEmpty().WithMessage("ProjectId is required.");

        RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future.");
    }
}

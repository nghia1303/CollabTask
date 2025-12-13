namespace CollabTask.Application;

public class TodoTaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public Guid ProjectId { get; set; }

    public TodoTaskDto(Guid id, string title, string description, DateTime dueDate, Guid projectId)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        ProjectId = projectId;
    }
}

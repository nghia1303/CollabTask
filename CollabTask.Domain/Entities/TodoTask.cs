using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace CollabTask.Domain.Entities
{
    public class TodoTask
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; } = string.Empty;
        public TodoTaskStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Guid ProjectId { get; private set; }

        public TodoTask() { }
        public TodoTask(string title, string? description, Guid projectId, DateTime? dueDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Task title cannot be empty.", nameof(title));
            }
            if (projectId == Guid.Empty)
            {
                throw new ArgumentException("Task must belong to a project.", nameof(projectId));
            }
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            ProjectId = projectId;
            CreatedDate = DateTime.UtcNow;
            DueDate = dueDate;
        }
        public void Update(string newTitle, string? newDescription, DateTime? newDueDate)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Task title cannot be empty.", nameof(newTitle));
            }
            Title = newTitle;
            Description = newDescription;
            DueDate = newDueDate;
        }
        public void MarkAsCompleted()
        {
            Status = TodoTaskStatus.Done;
        }
    }
}
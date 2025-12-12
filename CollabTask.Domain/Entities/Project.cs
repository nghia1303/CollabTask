using System.Reflection;

namespace CollabTask.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }

        // Relationship (sẽ dùng sau)
        private readonly List<TodoTask> _tasks = new();
        public IReadOnlyCollection<TodoTask> Tasks => _tasks.AsReadOnly();
        public Project() { }
        public Project(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Project name cannot be empty.", nameof(name));
            }
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            CreatedDate = DateTime.UtcNow;
        }

        public void Update(string newName, string? newDescription)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Project name cannot be empty.", nameof(newName));
            }
            Name = newName;
            Description = newDescription;
        }
    }
}
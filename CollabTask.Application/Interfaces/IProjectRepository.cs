using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllAsync();
    Task AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(Project project);
    Task<Project?> GetByIdWithTasksAsync(Guid id);
}

using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public interface ITodoTaskRepository
{
    Task<TodoTask?> GetByIdAsync(Guid id);
    Task<IEnumerable<TodoTask>> GetAllAsync();
    Task AddAsync(TodoTask todoTask);
    Task UpdateAsync(TodoTask todoTask);
    Task DeleteAsync(TodoTask todoTask);
}

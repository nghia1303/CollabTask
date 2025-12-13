using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public interface ITodoTaskService
{
    Task<Guid> CreateTodoTaskAsync(CreateTaskDto createTaskDto);
    Task<IEnumerable<TodoTaskDto>> GetAllAsync();
}

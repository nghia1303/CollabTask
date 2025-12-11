namespace CollabTask.Application;

public interface ITodoTaskService
{
    Task<Guid> CreateTodoTaskAsync(CreateTaskDto createTaskDto);
}

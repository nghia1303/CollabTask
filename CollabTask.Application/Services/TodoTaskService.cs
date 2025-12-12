using System.ComponentModel.DataAnnotations;
using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public class TodoTaskService : ITodoTaskService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITodoTaskRepository _todoTaskRepository;
    public TodoTaskService(IProjectRepository projectRepository, ITodoTaskRepository todoTaskRepository)
    {
        _projectRepository = projectRepository;
        _todoTaskRepository = todoTaskRepository;
    }

    public async Task<Guid> CreateTodoTaskAsync(CreateTaskDto createTaskDto)
    {
        var project = await _projectRepository.GetByIdAsync(createTaskDto.ProjectId);

        var todoTask = new TodoTask(createTaskDto.Title, createTaskDto.Description, createTaskDto.ProjectId, createTaskDto.DueDate);
        await _todoTaskRepository.AddAsync(todoTask);

        return todoTask.Id;
    }
}

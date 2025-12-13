using System.ComponentModel.DataAnnotations;
using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public class TodoTaskService : ITodoTaskService
{
    private readonly IUnitOfWork _unitOfWork;
    public TodoTaskService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> CreateTodoTaskAsync(CreateTaskDto createTaskDto)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(createTaskDto.ProjectId);

        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id: {createTaskDto.ProjectId} not exist.");
        }

        var todoTask = new TodoTask(createTaskDto.Title, createTaskDto.Description, createTaskDto.ProjectId, createTaskDto.DueDate);

        await _unitOfWork.TodoTasks.AddAsync(todoTask);
        await _unitOfWork.CompleteAsync();

        return todoTask.Id;
    }

    public async Task<IEnumerable<TodoTaskDto>> GetAllAsync()
    {
        var tasks = await _unitOfWork.TodoTasks.GetAllAsync();
        List<TodoTaskDto> taskList = new List<TodoTaskDto>();

        foreach (var t in tasks)
        {
            var taskDto = new TodoTaskDto(t.Id, t.Title, t.Description ?? string.Empty, t.DueDate ?? DateTime.MinValue, t.ProjectId);
            taskList.Add(taskDto);
        }

        return taskList;
    }
}

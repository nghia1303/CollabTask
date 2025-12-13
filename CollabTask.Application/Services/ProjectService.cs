using System.Reflection.Metadata.Ecma335;
using CollabTask.Application.Dtos;
using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> CreateProjectAsync(CreateProjectDto projectDto)
    {
        var project = new Project(projectDto.Name, projectDto.Description);

        await _unitOfWork.Projects.AddAsync(project);
        await _unitOfWork.CompleteAsync();

        return project.Id;
    }

    public async Task DeleteProjectAsync(Guid id)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(id);
        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id {id} not found.");
        }
        await _unitOfWork.Projects.DeleteAsync(project);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjectAsync()
    {
        var projects = await _unitOfWork.Projects.GetAllAsync();

        return projects.Select(p => new ProjectDto
        (
            p.Id,
            p.Name,
            p.Description,
            p.CreatedDate
        ));
    }

    public async Task<ProjectDto?> GetProjectById(Guid id)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(id);

        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id {id} not found.");
        }

        return new ProjectDto(project.Id, project.Name, project.Description, project.CreatedDate);
    }

    public async Task UpdateProjectAsync(Guid id, CreateProjectDto projectDto)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(id);

        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id {id} not found.");
        }

        project.Update(projectDto.Name, projectDto.Description);
        await _unitOfWork.Projects.UpdateAsync(project);
        await _unitOfWork.CompleteAsync();
    }

    public async Task CloneProjectAsync(Guid sourceProjectId)
    {
        var project = await _unitOfWork.Projects.GetByIdWithTasksAsync(sourceProjectId);

        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id: {sourceProjectId} does not exist.");
        }

        var newProject = new Project("Copy of" + project.Name, project.Description);

        await _unitOfWork.Projects.AddAsync(newProject);

        foreach (var t in project.Tasks)
        {
            var task = new TodoTask(t.Title, t.Description, newProject.Id, DateTime.UtcNow));
            await _unitOfWork.TodoTasks.AddAsync(task);
        }

        await _unitOfWork.CompleteAsync();
    }
}

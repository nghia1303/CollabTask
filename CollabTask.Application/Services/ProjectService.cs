using System.Reflection.Metadata.Ecma335;
using CollabTask.Application.Dtos;
using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;
    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<Guid> CreateProjectAsync(CreateProjectDto projectDto)
    {
        var project = new Project(projectDto.Name, projectDto.Description);

        await _repository.AddAsync(project);
        return project.Id;
    }

    public async Task DeleteProjectAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null)
        {
            throw new Exception("Không thể tìm thấy dự án");
        }
        await _repository.DeleteAsync(project);
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjectAsync()
    {
        var projects = await _repository.GetAllAsync();

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
        var project = await _repository.GetByIdAsync(id);

        if (project == null) return null;

        return new ProjectDto(project.Id, project.Name, project.Description, project.CreatedDate);
    }

    public async Task UpdateProjectAsync(Guid id, CreateProjectDto projectDto)
    {
        var project = await _repository.GetByIdAsync(id);

        if (project == null)
        {
            throw new Exception("Không thể tìm thấy dự án");
        }

        project.Name = projectDto.Name;
        project.Description = projectDto.Description;

        await _repository.UpdateAsync(project);
    }
}

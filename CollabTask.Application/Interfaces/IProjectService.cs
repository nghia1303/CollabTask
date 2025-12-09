using CollabTask.Application.Dtos;

namespace CollabTask.Application;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllProjectAsync();
    Task<ProjectDto?> GetProjectById(Guid id);
    Task<Guid> CreateProjectAsync(CreateProjectDto projectDto);
    Task UpdateProjectAsync(Guid id, CreateProjectDto projectDto);
    Task DeleteProjectAsync(Guid id);
}

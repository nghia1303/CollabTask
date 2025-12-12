using CollabTask.Application;
using CollabTask.Application.Dtos;
using CollabTask.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollabTask.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllProjectAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var project = await _projectService.GetProjectById(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto createProjectDto)
        {
            var newId = await _projectService.CreateProjectAsync(createProjectDto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { id = newId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateProjectDto projectDto)
        {
            await _projectService.UpdateProjectAsync(id, projectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}

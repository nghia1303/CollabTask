using CollabTask.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskService _service;
        public TodoTaskController(ITodoTaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var taskId = await _service.CreateTodoTaskAsync(createTaskDto);
            return Ok(new { id = taskId });
        }
    }
}

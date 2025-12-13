using CollabTask.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollabTask.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskService _service;
        public TodoTasksController(ITodoTaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var taskId = await _service.CreateTodoTaskAsync(createTaskDto);
            return Ok(new { id = taskId });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }
    }
}

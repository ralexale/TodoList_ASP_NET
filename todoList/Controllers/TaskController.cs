using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoList.DTOs.Request;
using todoList.DTOs.Response;
using todoList.Services;

namespace todoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet]
        public async Task<IEnumerable<TaskResponse>> Get() => await _taskService.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponse>> GetById(int id)
        {

            var task = await _taskService.GetById(id);
            if(task == null) return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponse>> Create(TaskRequest taskRequest)
        {
            var task = await _taskService.Create(taskRequest);
            return CreatedAtAction(nameof(GetById), new { id = task.Id}, task);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TaskResponse>> Update(int id)
        {
            var task = await _taskService.Update(id);
            if(task == null) return NotFound();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        async Task<IActionResult> Delete(int id)
        {
            var result = await _taskService.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    } 
}

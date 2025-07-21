using DeepStandingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<TaskModel> tasks = new()
    {
        new TaskModel { Title = "Learn Angular", Priority = "normal" },
        new TaskModel { Title = "Build UI", Priority = "high" }
    };

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> GetTasks() => Ok(tasks);

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskModel task)
        {
            if (task == null || string.IsNullOrEmpty(task.Title))
                return BadRequest("Invalid task");

            tasks.Add(task);

            return Ok(task);
        }

        [HttpDelete("{title}")]
        public IActionResult DeleteTask(string title)
        {
            var task = tasks.FirstOrDefault(t => t.Title == title);
            if (task == null)
                return NotFound("Task not found");

            tasks.Remove(task);
            return Ok();
        }

        [HttpPut("{title}")]
        public IActionResult UpdateTask(string title, [FromBody] TaskModel updatedTask)
        {
            var existingTask = tasks.FirstOrDefault(t => t.Title == title);
            if (existingTask == null)
                return NotFound("Task not found");

            // Update fields
            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.Priority = updatedTask.Priority;

            return Ok(existingTask);
        }



    }
}
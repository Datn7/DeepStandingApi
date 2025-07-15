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


            return Ok();
        }

    }
}
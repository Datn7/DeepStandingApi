using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<string> tasks = new() { "Learn Angular", "Build UI", "Connect API" };

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTasks() => Ok(tasks);

        [HttpPost]
        public ActionResult AddTask([FromBody] string task)
        {
            tasks.Add(task);
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionsController : ControllerBase
    {
        [HttpGet("list")]
        public IActionResult GetList()
        {
            var fruits = new List<string> { "Apple", "Banana", "Mango" };
            fruits.Add("Peach");
            return Ok(fruits);
        }

        [HttpGet("dictionary")]
        public IActionResult GetDictionary()
        {
            var countries = new Dictionary<string, string>
            {
                { "US", "United States" },
                { "DE", "Germany" },
                { "FR", "France" }
            };
            return Ok(countries);
        }

        [HttpGet("queue")]
        public IActionResult GetQueue()
        {
            var queue = new Queue<string>();
            queue.Enqueue("Task1");
            queue.Enqueue("Task2");
            queue.Enqueue("Task3");

            return Ok(queue.ToArray()); // because Queue can't be serialized directly
        }

        [HttpGet("stack")]
        public IActionResult GetStack()
        {
            var stack = new Stack<string>();
            stack.Push("Page1");
            stack.Push("Page2");
            stack.Push("Page3");

            return Ok(stack.ToArray()); // serialized as array (LIFO)
        }

        [HttpGet("hashset")]
        public IActionResult GetHashSet()
        {
            var set = new HashSet<string> { "C#", "C#", "Java", "Python", "Go" };
            return Ok(set.ToArray()); // unique values only
        }
    }
}

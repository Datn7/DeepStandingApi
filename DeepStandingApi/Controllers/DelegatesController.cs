using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DelegatesController : ControllerBase
    {
        // 1. Delegate definition
        public delegate string GreetingDelegate(string name);

        // 2. Action: takes input, returns void
        [HttpGet("action")]
        public IActionResult RunAction()
        {
            Action<string> sayHello = name => Console.WriteLine($"Hello, {name}!");
            sayHello("Datuna");

            return Ok("Action executed — check console log");
        }

        // 3. Func: takes input, returns output
        [HttpGet("func")]
        public IActionResult RunFunc()
        {
            Func<int, int, int> add = (a, b) => a + b;
            int result = add(4, 5);
            return Ok(new { a = 4, b = 5, result });
        }

        // 4. Predicate: returns boolean
        [HttpGet("predicate")]
        public IActionResult RunPredicate()
        {
            Predicate<int> isEven = x => x % 2 == 0;
            bool test = isEven(10);
            return Ok(new { number = 10, isEven = test });
        }

        // 5. Custom Delegate
        [HttpGet("delegate")]
        public IActionResult RunDelegate()
        {
            GreetingDelegate greet = name => $"Hello, {name}! This is a custom delegate.";
            string message = greet("Datuna");
            return Ok(message);
        }

        // 6. Event Simulation
        public class EventSimulator
        {
            public event Action<string>? OnDataReceived;

            public string Simulate(string input)
            {
                OnDataReceived?.Invoke(input); // trigger event
                return $"Received and triggered event with '{input}'";
            }
        }

        [HttpGet("event")]
        public IActionResult SimulateEvent()
        {
            var simulator = new EventSimulator();

            string log = "";
            simulator.OnDataReceived += (data) =>
            {
                log = $"Event triggered with data: {data}";
                Console.WriteLine(log);
            };

            string result = simulator.Simulate("Angular Button Click");
            return Ok(new { result, log });
        }
    }
}

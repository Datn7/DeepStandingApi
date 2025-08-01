using Microsoft.AspNetCore.Mvc;

namespace CSharpBasicsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasicsController : ControllerBase
    {
        // Step 1: Hello World
        [HttpGet("hello")]
        public IActionResult SayHello()
        {
            return Ok("Hello from C# Web API!");
        }

        // Step 2: Variables & Types
        [HttpGet("userinfo")]
        public IActionResult GetUserInfo()
        {
            string name = "Alice";
            int age = 25;
            bool isStudent = true;

            return Ok(new { name, age, isStudent });
        }

        // Step 3: Control Structures - Even or Odd
        [HttpGet("evenodd/{number}")]
        public IActionResult CheckEvenOdd(int number)
        {
            string result = number % 2 == 0 ? "Even" : "Odd";
            return Ok(new { number, result });
        }

        // Step 4: Calculator with Method
        [HttpGet("calculate")]
        public IActionResult Calculate(int a, int b, string op)
        {
            double result = PerformCalculation(a, b, op);
            return Ok(new { a, b, op, result });
        }

        private double PerformCalculation(int a, int b, string op)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => b != 0 ? (double)a / b : double.NaN,
                _ => 0
            };
        }

        // Step 5: Basic OOP - Book & Library
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }

        private static List<Book> _library = new()
        {
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 },
            new Book { Title = "Clean Code", Author = "Robert C. Martin", Year = 2008 }
        };

        [HttpGet("books")]
        public IActionResult GetBooks()
        {
            return Ok(_library);
        }

        [HttpPost("books")]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            _library.Add(newBook);
            return Ok(new { message = "Book added!", newBook });
        }
    }
}

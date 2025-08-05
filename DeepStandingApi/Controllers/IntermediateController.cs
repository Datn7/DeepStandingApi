using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IntermediateController : ControllerBase
{
    [HttpGet("exceptions")]
    public IActionResult GetExceptions() => Ok(new[]
    {
        new {
            title = "Try/Catch Example",
            code = @"try {
    int x = int.Parse(""not a number"");
} catch (FormatException ex) {
    Console.WriteLine($""Error: {ex.Message}"");
}",
            output = "Error: Input string was not in a correct format.",
            color = "red"
        },
        new {
            title = "Custom Exception",
            code = @"throw new InvalidOperationException(""Invalid operation!"");",
            output = "Unhandled exception: Invalid operation!",
            color = "orange"
        }
    });

    [HttpGet("generics")]
    public IActionResult GetGenerics() => Ok(new[]
    {
        new {
            title = "Generic Method",
            code = @"public T Echo<T>(T input) {
    return input;
}",
            output = "Returns the input of any type.",
            color = "green"
        },
        new {
            title = "Generic Class",
            code = @"class Box<T> {
    public T Content;
}",
            output = "A class that can store any type of data.",
            color = "blue"
        }
    });

    [HttpGet("collections")]
    public IActionResult GetCollections() => Ok(new[]
    {
        new {
            title = "List Example",
            code = @"List<string> names = new List<string> { ""Alice"", ""Bob"" };
Console.WriteLine(names[0]);",
            output = "Alice",
            color = "green"
        },
        new {
            title = "Dictionary Example",
            code = @"var dict = new Dictionary<int, string> {
    { 1, ""One"" },
    { 2, ""Two"" }
};",
            output = "Key-value store with quick lookup.",
            color = "blue"
        }
    });

    [HttpGet("delegates")]
    public IActionResult GetDelegates() => Ok(new[]
    {
        new {
            title = "Delegate Syntax",
            code = @"delegate int Operation(int a, int b);
Operation add = (a, b) => a + b;",
            output = "Lambda stored in delegate.",
            color = "purple"
        }
    });

    [HttpGet("events")]
    public IActionResult GetEvents() => Ok(new[]
    {
        new {
            title = "Basic Event",
            code = @"public event Action OnClick;
OnClick += () => Console.WriteLine(""Clicked!"");",
            output = "Subscribed method prints 'Clicked!'",
            color = "blue"
        }
    });

    [HttpGet("linq")]
    public IActionResult GetLinq() => Ok(new[]
    {
        new {
            title = "LINQ Where & Select",
            code = @"var results = nums.Where(n => n > 3).Select(n => n * 2);",
            output = "Filters > 3, then doubles",
            color = "green"
        },
        new {
            title = "LINQ GroupBy",
            code = @"people.GroupBy(p => p.Age);",
            output = "Groups people by age.",
            color = "orange"
        }
    });

    [HttpGet("fileio")]
    public IActionResult GetFileIO() => Ok(new[]
    {
        new {
            title = "Write to File",
            code = @"File.WriteAllText(""log.txt"", ""Hello!"");",
            output = "Writes Hello! to log.txt",
            color = "yellow"
        },
        new {
            title = "Read from File",
            code = @"string content = File.ReadAllText(""log.txt"");",
            output = "Reads all text from file",
            color = "green"
        }
    });

    [HttpGet("async")]
    public IActionResult GetAsync() => Ok(new[]
    {
        new {
            title = "Async/Await",
            code = @"async Task<int> GetDataAsync() {
    await Task.Delay(1000);
    return 42;
}",
            output = "Waits 1s, returns 42",
            color = "purple"
        },
        new {
            title = "Using Task<T>",
            code = @"Task<string> task = Task.FromResult(""Hello!"");",
            output = "Creates a completed task",
            color = "blue"
        }
    });
}

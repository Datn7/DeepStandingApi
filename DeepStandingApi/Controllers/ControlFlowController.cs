using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControlFlowController : ControllerBase
{
    [HttpGet("conditionals")]
    public IActionResult GetConditionals()
    {
        var examples = new[]
        {
            new {
                title = "Basic if/else",
                code = @"int age = 18;
if (age >= 18)
{
    Console.WriteLine(""Adult"");
}
else
{
    Console.WriteLine(""Minor"");
}",
                output = "Adult",
                color = "blue"
            },
            new {
                title = "Switch Statement",
                code = @"int age = 18;
switch (age)
{
    case 18:
        Console.WriteLine(""Just turned adult"");
        break;
    default:
        Console.WriteLine(""Other age"");
        break;
}",
                output = "Just turned adult",
                color = "purple"
            }
        };

        return Ok(examples);
    }

    [HttpGet("loops")]
    public IActionResult GetLoops()
    {
        var examples = new[]
        {
            new {
                title = "For Loop",
                code = @"for (int i = 0; i < 3; i++)
{
    Console.WriteLine(i);
}",
                output = "0\n1\n2",
                color = "green"
            },
            new {
                title = "While Loop",
                code = @"int j = 0;
while (j < 3)
{
    Console.WriteLine(j);
    j++;
}",
                output = "0\n1\n2",
                color = "blue"
            },
            new {
                title = "Do-While Loop",
                code = @"int k = 0;
do
{
    Console.WriteLine(k);
    k++;
} while (k < 3);",
                output = "0\n1\n2",
                color = "orange"
            },
            new {
                title = "Foreach Loop",
                code = @"string[] items = { ""a"", ""b"", ""c"" };
foreach (var item in items)
{
    Console.WriteLine(item);
}",
                output = "a\nb\nc",
                color = "purple"
            }
        };

        return Ok(examples);
    }

    [HttpGet("arrays")]
    public IActionResult GetArrays()
    {
        var examples = new[]
        {
            new {
                title = "Single-dimensional Array",
                code = @"int[] nums = { 1, 2, 3 };
foreach (int n in nums)
{
    Console.WriteLine(n);
}",
                output = "1\n2\n3",
                color = "green"
            },
            new {
                title = "Multi-dimensional Array",
                code = @"int[,] matrix = new int[2, 2] { {1, 2}, {3, 4} };
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.WriteLine(matrix[i, j]);
    }
}",
                output = "1\n2\n3\n4",
                color = "blue"
            },
            new {
                title = "Jagged Array",
                code = @"int[][] jagged = new int[2][];
jagged[0] = new int[] { 1, 2 };
jagged[1] = new int[] { 3, 4, 5 };
foreach (var row in jagged)
{
    foreach (var val in row)
    {
        Console.WriteLine(val);
    }
}",
                output = "1\n2\n3\n4\n5",
                color = "orange"
            }
        };

        return Ok(examples);
    }

    [HttpGet("methods")]
    public IActionResult GetMethods()
    {
        var examples = new[]
        {
            new {
                title = "Greet Method",
                code = @"void Greet(string name)
{
    Console.WriteLine(""Hello "" + name);
}

Greet(""John"");",
                output = "Hello John",
                color = "green"
            },
            new {
                title = "Add Method",
                code = @"int Add(int a, int b)
{
    return a + b;
}

Console.WriteLine(Add(10, 5));",
                output = "15",
                color = "blue"
            },
            new {
                title = "Update by Ref",
                code = @"void Update(ref int x)
{
    x += 10;
}

int value = 42;
Update(ref value);
Console.WriteLine(value);",
                output = "52",
                color = "purple"
            },
            new {
                title = "Return by Out",
                code = @"void TryGet(out int result)
{
    result = 42;
}

int val;
TryGet(out val);
Console.WriteLine(val);",
                output = "42",
                color = "orange"
            }
        };

        return Ok(examples);
    }

    [HttpGet("strings")]
    public IActionResult GetStrings()
    {
        var examples = new[]
        {
            new {
                title = "Concatenation",
                code = @"string firstName = ""John"";
string lastName = ""Doe"";
Console.WriteLine(firstName + "" "" + lastName);",
                output = "John Doe",
                color = "green"
            },
            new {
                title = "String Interpolation",
                code = @"string name = ""Alice"";
Console.WriteLine($""Hello, {name}!"");",
                output = "Hello, Alice!",
                color = "blue"
            },
            new {
                title = "String.Format",
                code = @"int age = 30;
Console.WriteLine(string.Format(""Age: {0}"", age));",
                output = "Age: 30",
                color = "purple"
            }
        };

        return Ok(examples);
    }

    [HttpGet("comments")]
    public IActionResult GetComments()
    {
        var examples = new[]
        {
            new {
                title = "Single-line Comment",
                code = @"// This is a single-line comment
Console.WriteLine(""Code executes as normal"");",
                output = "Code executes as normal",
                color = "green"
            },
            new {
                title = "Multi-line Comment",
                code = @"/* This is a 
   multi-line comment */
Console.WriteLine(""Still runs!"");",
                output = "Still runs!",
                color = "blue"
            },
            new {
                title = "Best Practices",
                code = @"// Use meaningful names
int userAge = 25;

// Avoid magic numbers
const int MaxLoginAttempts = 3;",
                output = "// No output - best practice guidance",
                color = "orange"
            }
        };

        return Ok(examples);
    }
}

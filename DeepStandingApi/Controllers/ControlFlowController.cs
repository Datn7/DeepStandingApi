using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControlFlowController : ControllerBase
{
    [HttpGet("conditionals")]
    public IActionResult GetConditionals()
    {
        var data = new[] { "if", "else", "else if", "switch" };
        return Ok(data);
    }

    [HttpGet("loops")]
    public IActionResult GetLoops()
    {
        var data = new[] { "for", "while", "do-while", "foreach" };
        return Ok(data);
    }

    [HttpGet("arrays")]
    public IActionResult GetArrays()
    {
        var data = new[] {
            "Single-dimensional: int[] nums = { 1, 2, 3 };",
            "Multi-dimensional: int[,] matrix = new int[2,2];",
            "Jagged: int[][] jagged = new int[2][];"
        };
        return Ok(data);
    }

    [HttpGet("methods")]
    public IActionResult GetMethods()
    {
        var data = new[] {
            "void Greet(string name)",
            "int Add(int a, int b)",
            "ref, out parameters",
            "Method overloading supported"
        };
        return Ok(data);
    }

    [HttpGet("strings")]
    public IActionResult GetStrings()
    {
        var data = new[] {
            "Concatenation: name + \" \" + surname",
            "String interpolation: $\"Hello, {name}\"",
            "string.Format, StringBuilder"
        };
        return Ok(data);
    }

    [HttpGet("comments")]
    public IActionResult GetComments()
    {
        var data = new[] {
            "// Single line comment",
            "/* Multi-line\n comment */",
            "Best Practices: meaningful names, consistent formatting, avoid magic numbers"
        };
        return Ok(data);
    }
}

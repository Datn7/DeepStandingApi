using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FundamentalsController : ControllerBase
{
    [HttpGet("data-types")]
    public IActionResult GetDataTypes()
    {
        var dataTypes = new
        {
            ValueTypes = new[] { "int", "float", "bool", "char", "double", "decimal" },
            ReferenceTypes = new[] { "string", "object", "dynamic", "arrays", "class", "interface" }
        };

        return Ok(dataTypes);
    }

    [HttpGet("variables")]
    public IActionResult GetVariables()
    {
        var variables = new
        {
            Declaration = "int x;",
            Initialization = "int x = 5;",
            Scope = "Global, local, block-level scopes determine variable visibility"
        };

        return Ok(variables);
    }

    [HttpGet("operators")]
    public IActionResult GetOperators()
    {
        var operators = new
        {
            Arithmetic = new[] { "+", "-", "*", "/", "%" },
            Assignment = new[] { "=", "+=", "-=", "*=", "/=" },
            Comparison = new[] { "==", "!=", "<", ">", "<=", ">=" },
            Logical = new[] { "&&", "||", "!" },
            Bitwise = new[] { "&", "|", "^", "~", "<<", ">>" }
        };

        return Ok(operators);
    }
}
